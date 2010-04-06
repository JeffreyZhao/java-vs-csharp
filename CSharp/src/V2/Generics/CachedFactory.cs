using System;
using System.Collections.Generic;
using System.Text;

namespace V2.Generics
{
    public interface IFactory<T>
    {
        void Initialize();

        T Create();
    }

    public static class CachedFactory<TFactory, T>
        where TFactory : IFactory<T>, new()
    {
        static CachedFactory()
        {
            s_factoryInstance = new TFactory();
            s_factoryInstance.Initialize();
        }

        private static TFactory s_factoryInstance;

        public static T Create()
        {
            return s_factoryInstance.Create();
        }
    }
}
