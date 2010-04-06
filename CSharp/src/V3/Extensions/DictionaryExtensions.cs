using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace V3.Extensions
{
    public static class DictionaryExtensions
    {
        public static TDictionary CopyFrom<TDictionary, TKey, TValue>(this TDictionary source, IDictionary<TKey, TValue> copy)
            where TDictionary : IDictionary<TKey, TValue>
        {
            foreach (var pair in copy)
            {
                source.Add(pair.Key, pair.Value);
            }

            return source;
        }

        public static TDictionary CopyFrom<TDictionary, TKey, TValue>(this TDictionary source, IDictionary<TKey, TValue> copy, IEnumerable<TKey> keys)
            where TDictionary : IDictionary<TKey, TValue>
        {
            foreach (var key in keys)
            {
                source.Add(key, copy[key]);
            }

            return source;
        }

        public static TDictionary RemoveKeys<TDictionary, TKey, TValue>(this TDictionary source, IEnumerable<TKey> keys)
            where TDictionary : IDictionary<TKey, TValue>
        {
            foreach (var key in keys)
            {
                source.Remove(key);
            }

            return source;
        }

        public static IDictionary<TKey, TValue> RemoveKeys<TKey, TValue>(this IDictionary<TKey, TValue> source, IEnumerable<TKey> keys)
        {
            foreach (var key in keys)
            {
                source.Remove(key);
            }

            return source;
        }

        public static bool TryRemove<TKey, TValue>(this IDictionary<TKey, object> source, TKey key, out TValue value)
        {
            value = default(TValue);

            object obj;
            if (!source.TryGetValue(key, out obj)) return false;

            if (!(obj is TValue)) return false;

            value = (TValue)obj;
            source.Remove(key);
            return true;
        }

        public static bool TryRemove<TKey, TValue>(this IDictionary<TKey, TValue> source, TKey key, out TValue value)
        {
            if (!source.TryGetValue(key, out value)) return false;

            source.Remove(key);
            return true;
        }

        public static bool TryGetValue<TKey, TValue>(this IDictionary<TKey, object> source, TKey key, out TValue value)
        {
            value = default(TValue);

            object obj;
            if (!source.TryGetValue(key, out obj)) return false;

            if (!(obj is TValue)) return false;

            value = (TValue)obj;
            return true;
        }

    }
}
