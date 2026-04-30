using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Text;

namespace PractiZing.Api.Common.Authorize
{
    public class MemoryCache
    {
        // variable from Microsoft.Extensions.Caching.Memory to set or get element by key    
        private static IMemoryCache _memoryCache;
        // variable from Microsoft.Extensions.Caching.Memory 
        private static MemoryCacheEntryOptions _cacheExpiration;
        public MemoryCache(IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;
        }
        /// <summary>
        /// Remove from memory cache where use smallToken as key
        /// </summary>
        /// <param name="smallToken"></param>
        public static void Remove(string smallToken)
        {
            _memoryCache.Remove(smallToken);
        }
        /// <summary>
        /// set response of logged user response smallToken as key and response as value
        /// </summary>
        /// <param name="smallToken"></param>
        /// <param name="result"></param>
        public static void Set(string smallToken, object result)
        {
            _cacheExpiration = new MemoryCacheEntryOptions();
            _cacheExpiration.AbsoluteExpiration = DateTime.Now.AddDays(30);
            _cacheExpiration.Priority = CacheItemPriority.Normal;
            var existingItem = Get(smallToken);
            if (existingItem == null)
                _memoryCache.Set(smallToken, result, _cacheExpiration);
        }
        /// <summary>
        /// get real token from memory cache 
        /// </summary>
        /// <param name="smallToken"></param>
        /// <returns></returns>
        public static dynamic Get(string smallToken)
        {
            return _memoryCache.Get(smallToken);
        }
    }
}
