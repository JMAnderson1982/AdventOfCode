namespace AdventOfCode.Shared.Extensions
{
    using System;
    using System.Collections.Generic;

    public static class DictionaryExtension
    {
        public static TValue GetAndCreate<TKey,TValue>(this Dictionary<TKey,TValue> dict, TKey key)
            where TValue : new()
        {
            TValue value;
            if( !dict.TryGetValue(key, out value) )
            {
                value = new TValue();
                dict[key] = value;
            }
            return value;
        }
    }
}