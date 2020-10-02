using System;
using System.Runtime.Caching;

namespace OnlineCourses.Implementation.Helper
{
    public class Cache
    {
        public static TEntity Get<TEntity>(string key, Func<TEntity> func, double expire = 2)
        {
            ObjectCache cache = MemoryCache.Default;
            var newValue = new Lazy<TEntity>(func);
            var policy = new CacheItemPolicy { AbsoluteExpiration = DateTimeOffset.Now.AddMinutes(expire) };
            var value = cache.AddOrGetExisting(key, newValue, policy) as Lazy<TEntity>;

            return (value ?? newValue).Value;
        }
    }
}
