using System;
using System.Collections.Generic;
using System.Text;

namespace V2.Generics
{
    public static class Retriever
    {
        public static T TryGet<T>(IDictionary<string, object> dict, string key, T defaults)
        {
            object value;
            if (dict.TryGetValue(key, out value) && value is T)
            {
                return (T)value; 
            }
            else
            {
                return defaults;
            }
        }
    }

    public static class RetrieverUsage
    {
        public static void TryGet()
        {
            var dict = new Dictionary<string, object>();

            int intValue = Retriever.TryGet(dict, "UserID", 0);
            string userName = Retriever.TryGet(dict, "UserName", "");
        }
    }
}
