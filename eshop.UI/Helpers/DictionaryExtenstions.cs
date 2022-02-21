using System;
using System.Collections.Generic;

namespace eshop.UI.Helpers
{
    public static class DictionaryExtenstions
    {
        public static T GetValueByKey<T>(this Dictionary<string, object> collection, string key)
        {
            if (collection == null) return default(T);

            object value = collection.GetValueByKey(key);
            if (value == null) return default(T);

            return (T)value;
        }

        private static object GetValueByKey(this Dictionary<string, object> collection, string key)
        {
            if (string.IsNullOrWhiteSpace(key)) throw new ArgumentNullException(nameof(key));

            if (!collection.ContainsKey(key)) return null;

            return collection[key];
        }
    }
}