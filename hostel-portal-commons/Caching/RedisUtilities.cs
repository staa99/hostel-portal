using System;
using System.Collections.Generic;
using StackExchange.Redis;


namespace Staawork.Funaab.HostelPortal.Commons.Caching
{
    public static class RedisUtilities
    {
        public static HashEntry[] MapDictionaryToHashEntries<TKey, TValue>(
            ICollection<KeyValuePair<TKey, TValue>> dictionary,
            Func<KeyValuePair<TKey, TValue>, HashEntry>
                convert)
            where TKey : notnull
        {
            var count = dictionary.Count;
            var result = new HashEntry[count];
            var i = 0;
            foreach (var pair in dictionary)
            {
                result[i] = convert(pair);
                i++;
            }

            return result;
        }


        public static void MapHashEntriesToDictionary<TKey, TValue>(IEnumerable<HashEntry>                      map,
                                                                    IDictionary<TKey, TValue>                   result,
                                                                    Func<HashEntry, KeyValuePair<TKey, TValue>> convert)
            where TKey : notnull
        {
            foreach (var entry in map)
            {
                var (key, value) = convert(entry);
                result[key] = value;
            }
        }


        public static HashEntry MapStringPairToHashEntry(KeyValuePair<string, string> pair) =>
            new HashEntry(pair.Key, pair.Value);
    }
}