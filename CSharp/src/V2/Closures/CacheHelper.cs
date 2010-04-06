using System;
using System.Collections.Generic;
using System.Text;

namespace V2.Closures
{
    public interface ICache
    {
        void Set(string key, object value);

        object Get(string key);
    }

    public static class CacheHelper
    {
        // this pattern is important for concurrent dictionary
        public static T Get<T>(ICache cache, string key, Func<T> getter)
        {
            var value = cache.Get(key);
            if (value != null && value is T) return (T)value;

            var newValue = getter();
            cache.Set(key, newValue);

            return newValue;
        }
    }

    public class CacheHelperUsage
    {
        public User GetUser(int id)
        {
            return CacheHelper.Get(s_cache, "User_" + id,
                delegate { return GetUserFromDB(id); });

            // return CacheHelper.Get(s_cache, "User_" + id, () => GetUserFromDB(id));
        }

        static ICache s_cache = null;

        private User GetUserFromDB(int id)
        {
            return new User();
        }
    }

    public class User { }
}
