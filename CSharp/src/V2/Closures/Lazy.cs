using System;
using System.Collections.Generic;
using System.Text;

namespace V2.Closures
{
    public class BigInstanceA { }

    public class BigInstanceB { }

    public class Core
    {
        private object m_mutexA = new object();
        private bool m_initializedA = false;
        private BigInstanceA m_instanceA = null;

        public BigInstanceA InstanceA
        {
            get
            {
                if (!this.m_initializedA)
                {
                    lock (this.m_mutexA)
                    {
                        if (!this.m_initializedA)
                        {
                            this.m_instanceA = new BigInstanceA();
                            this.m_initializedA = true;
                        }
                    }
                }

                return this.m_instanceA;
            }
        }

        #region BigInstanceB with Bug

        private object m_mutexB = new object();
        private bool m_initializedB = false;
        private BigInstanceB m_instanceB = null;

        public BigInstanceB InstanceB
        {
            get
            {
                if (!this.m_initializedB)
                {
                    lock (this.m_mutexB)
                    {
                        if (!this.m_initializedB)
                        {
                            this.m_instanceB = new BigInstanceB();
                            this.m_initializedA = true;
                        }
                    }
                }

                return this.m_instanceB;
            }
        }

        #endregion
    }


    public class Lazy<T>
    {
        public Lazy(Func<T> func)
        {
            this.m_initialized = false;
            this.m_func = func;
            this.m_mutex = new object();
        }

        private Func<T> m_func;

        private bool m_initialized;
        private object m_mutex;
        private T m_value;

        public T Value
        {
            get
            {
                if (!this.m_initialized)
                {
                    lock (this.m_mutex)
                    {
                        if (!this.m_initialized)
                        {
                            this.m_value = this.m_func();
                            this.m_func = null;
                            this.m_initialized = true;
                        }
                    }
                }

                return this.m_value;
            }
        }
    }

    public class BetterCore
    {
        private Lazy<BigInstanceA> m_lazyInstanceA = new Lazy<BigInstanceA>(delegate { return new BigInstanceA(); });
        public BigInstanceA InstanceA { get { return this.m_lazyInstanceA.Value; } }

        private Lazy<BigInstanceB> m_lazyInstanceB = new Lazy<BigInstanceB>(() => new BigInstanceB());
        public BigInstanceB InstanceB { get { return this.m_lazyInstanceB.Value; } }
    }
}
