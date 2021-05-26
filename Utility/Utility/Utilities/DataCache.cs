using System;
using System.Linq;
using System.Runtime.Caching;

namespace Utility.Utilities
{
    public class DataCache : MemoryCache
    {
        public DataCache() : base("dataCache")
        { 
        
        }

        public static T GetCachedItem<T>(string key) where T : class
        {
            try
            {
                ObjectCache cache = MemoryCache.Default;
                return (T)cache[key];
            }
            catch
            {
                return null;
            }
        }

        public static void SetCachedItem<T>(T obj, string key)
        {
            if (obj != null)
            {
                ObjectCache cache = MemoryCache.Default;
                cache.Set(key, obj, GetCachePolicy());
            }
        }

        public static CacheItemPolicy GetCachePolicy()
        {
            CacheItemPolicy policy = new CacheItemPolicy();

            policy.Priority = CacheItemPriority.Default;
            policy.SlidingExpiration = TimeSpan.FromHours(2.0);

            return policy;
        }

        public static void FlushAllCache()
        {
            ObjectCache cache = MemoryCache.Default;

            cache.Select(kv => kv.Key).ToList().ForEach(
                k => cache.Remove(k)    
            );
        }

        public static void RemoveCacheByKey(string key)
        {
            ObjectCache cache = MemoryCache.Default;
            cache.Remove(key);
        }
    }
}
