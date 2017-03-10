using System;
using System.Web;
using System.Web.Caching;
using Services.Infrastructure.Interfaces;

namespace Services.Infrastructure
{
    /// <summary>
    /// Sample of caching class. We generally do not want the mess with HttpContext in the services layer but for this sample we ignoring that
    /// </summary>
    public class CachingAsp : ICache
    {
        private readonly IConfig _config;

        public CachingAsp(IConfig config)
        {
            _config = config;
        }

        #region ICache Members

        public TResult Get<TResult>(string keyName) where TResult : class
        {
            return HttpContext.Current.Cache.Get(keyName) as TResult;
        }

        public object Get(string keyName)
        {
            return HttpContext.Current.Cache.Get(keyName);
        }

        public void Add<TItem>(string keyName, TItem item)
        {
            HttpContext.Current.Cache.Add(keyName, item, null, DateTime.Now.AddMinutes(_config.CacheTime),
                                          Cache.NoSlidingExpiration, CacheItemPriority.High, null);
        }

        #endregion
    }
}