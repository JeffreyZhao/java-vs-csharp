using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace V2.Yields
{
    public class Fibonacci : IEnumerable<int>
    {
        public class Enumerator : IEnumerator<int>
        {
            private int m_state = 0;
            private int m_current;
            private int m_last0;
            private int m_last1;

            public bool MoveNext()
            {
                if (this.m_state == 0) // first
                {
                    this.m_current = 0;

                    this.m_state = 1;
                }
                else if (this.m_state == 1)
                {
                    this.m_current = 1;
                    this.m_last1 = 0;

                    this.m_state = 2;
                }
                else
                {
                    this.m_last0 = this.m_last1;
                    this.m_last1 = this.m_current;
                    this.m_current = this.m_last0 + this.m_last1;
                }

                return true;
            }

            public int Current { get { return this.m_current; } }
            object IEnumerator.Current { get { return this.Current; } }

            public void Reset() { }
            public void Dispose() { }
        }

        public IEnumerator<int> GetEnumerator()
        {
            return new Enumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }

    public static class FibonacciGenerator
    {
        public static IEnumerable<int> Generate()
        {
            return new Fibonacci();
        }

        public static IEnumerable<int> GenerateWithYield()
        {
            yield return 0;
            yield return 1;

            int last0 = 0, last1 = 1, current;

            while (true)
            {
                current = last0 + last1;
                yield return current;

                last0 = last1;
                last1 = current;
            }
        }
    }
}
