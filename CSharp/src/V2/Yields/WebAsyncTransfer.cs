using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Web;
using System.Net;
using Wintellect.Threading.AsyncProgModel;

namespace V2.Yields
{
    public class CompletedEventArgs : EventArgs
    {
        public CompletedEventArgs(Exception ex)
        {
            this.Error = ex;
        }

        public Exception Error { get; private set; }
    }

    public class WebAsyncTransfer
    {
        private HttpContext m_context;
        private WebRequest m_request;
        private WebResponse m_response;
        private Stream m_streamIn;
        private Stream m_streamOut;

        public void StartAsync(HttpContext context, string url)
        {
            this.m_context = context;

            this.m_request = HttpWebRequest.Create(url);
            this.m_request.BeginGetResponse(this.EndGetResponseCallback, null);
        }

        private void EndGetResponseCallback(IAsyncResult ar)
        {
            try
            {
                this.m_response = this.m_request.EndGetResponse(ar);
                this.m_context.Response.ContentType = this.m_response.ContentType;

                var buffer = new byte[1024];
                this.m_streamIn = this.m_response.GetResponseStream();
                this.m_streamOut = this.m_context.Response.OutputStream;

                this.m_streamIn.BeginRead(
                    buffer, 0, buffer.Length,
                    this.EndReadInputStreamCallback, buffer);
            }
            catch (Exception ex)
            {
                this.OnCompleted(ex);
            }
        }

        private void EndReadInputStreamCallback(IAsyncResult ar)
        {
            var buffer = (byte[])ar.AsyncState;
            int lengthRead;

            try
            {
                lengthRead = this.m_streamIn.EndRead(ar);
            }
            catch (Exception ex)
            {
                this.OnCompleted(ex);
                return;
            }

            if (lengthRead <= 0)
            {
                this.OnCompleted(null);
            }
            else
            {
                try
                {
                    this.m_streamOut.BeginWrite(
                        buffer, 0, lengthRead,
                        this.EndWriteOutputStreamCallback, buffer);
                }
                catch (Exception ex)
                {
                    this.OnCompleted(ex);
                }
            }
        }

        private void EndWriteOutputStreamCallback(IAsyncResult ar)
        {
            try
            {
                this.m_streamOut.EndWrite(ar);

                var buffer = (byte[])ar.AsyncState;
                this.m_streamIn.BeginRead(
                    buffer, 0, buffer.Length,
                    this.EndReadInputStreamCallback, buffer);
            }
            catch (Exception ex)
            {
                this.OnCompleted(ex);
            }
        }

        private void OnCompleted(Exception ex)
        {
            if (this.m_response != null)
            {
                this.m_response.Close();
                this.m_response = null;
            }

            var handler = this.Completed;
            if (handler != null)
            {
                handler(this, new CompletedEventArgs(ex));
            }
        }

        public event EventHandler<CompletedEventArgs> Completed;
    }

    public class YieldWebAsyncTransfer
    {
        private static IEnumerator<int> GenerateTransferTask(
            AsyncEnumerator ae, HttpContext context, string url)
        {
            WebRequest request = WebRequest.Create(url);
            request.BeginGetResponse(ae.End(), null);
            yield return 1;

            using (WebResponse response = request.EndGetResponse(ae.DequeueAsyncResult()))
            {
                Stream streamIn = response.GetResponseStream();
                Stream streamOut = context.Response.OutputStream;
                byte[] buffer = new byte[1024];

                while (true)
                {
                    streamIn.BeginRead(buffer, 0, buffer.Length, ae.End(), null);
                    yield return 1;
                    int lengthRead = streamIn.EndRead(ae.DequeueAsyncResult());

                    streamOut.BeginWrite(buffer, 0, lengthRead, ae.End(), null);
                    yield return 1;
                    streamOut.EndWrite(ae.DequeueAsyncResult());
                }
            }
        }

        private AsyncEnumerator m_asyncEnumerator;

        public void StartAsync(HttpContext context, string url)
        {
            this.m_asyncEnumerator = new AsyncEnumerator();
            var asyncTask = GenerateTransferTask(this.m_asyncEnumerator, context, url);
            this.m_asyncEnumerator.BeginExecute(asyncTask, this.EndExecuteCallback);
        }

        private void EndExecuteCallback(IAsyncResult ar)
        {
            Exception error = null;
            try
            {
                this.m_asyncEnumerator.EndExecute(ar);
            }
            catch (Exception ex)
            {
                error = ex;
            }

            var handler = this.Completed;
            if (handler != null)
            {
                handler(this, new CompletedEventArgs(error));
            }
        }

        public event EventHandler<CompletedEventArgs> Completed;
    }
}
