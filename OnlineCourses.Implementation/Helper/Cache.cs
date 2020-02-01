using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;
using System.Text;
using System.Threading.Tasks;

namespace OnlineCourses.Implementation.Helper
{
    public class Cache
    {
        public static TEntity Get<TEntity>(string key, Func<TEntity> func, double expire = 2)
        {
            ObjectCache cache = MemoryCache.Default;
            var newValue = new  Lazy<TEntity>(func);
            var policy = new CacheItemPolicy { AbsoluteExpiration = DateTimeOffset.Now.AddHours(expire) };
            var value = cache.AddOrGetExisting(key,newValue,policy) as Lazy<TEntity>;

            return (value ?? newValue).Value;
        }
    }
}
