using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Caching;

namespace PetAdopt.Web.Infrastructure.Caching
{
    public class InMemoryCache : ICacheService
    {
        public T Get<T>(string cacheId, Func<T> getItemCallback, TimeSpan? duration = null) where T : class
        {
            T item = HttpRuntime.Cache.Get(cacheId) as T;
            if (item == null)
            {
                item = getItemCallback();
                if (duration == null)
                {
                    HttpContext.Current.Cache.Insert(cacheId, item);
                }
                else
                {
                    HttpContext.Current.Cache.Insert(cacheId, item, null, Cache.NoAbsoluteExpiration, duration.Value);
                }
                
            }
            return item;
        }

        public void Clear(string cacheId)
        {
            HttpRuntime.Cache.Remove(cacheId);
        }
    }
}