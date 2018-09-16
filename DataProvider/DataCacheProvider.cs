using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Caching;

namespace DataProvider
{
    public class DataCacheProvider
    {
        private static ObjectCache cache = MemoryCache.Default;
        private CacheItemPolicy policy = null;
        private CacheEntryRemovedCallback removalCallback = null;

        public void AddToDataCache(String cacheKeyName, Object cacheItem, CachePriority cacheItemPriority, List<String> filePath)
        {
            removalCallback = new CacheEntryRemovedCallback(this.CacheItemRemovedCallback);
            policy = new CacheItemPolicy();
            policy.Priority = (cacheItemPriority == CachePriority.Default) ? CacheItemPriority.Default : CacheItemPriority.NotRemovable;
            
            //policy.AbsoluteExpiration = DateTimeOffset.Now.AddSeconds(10.00);
            policy.RemovedCallback = removalCallback;
            policy.ChangeMonitors.Add(new HostFileChangeMonitor(filePath));

            // Add the Item cache 
            cache.Set(cacheKeyName, cacheItem, policy);
        }

        private void CacheItemRemovedCallback(CacheEntryRemovedArguments arguments)
        {
            arguments.CacheItem.Value.ToString();
        }

        public Object GetDataCachedItem(string cacheKeyName)
        {
            if (cache.Contains(cacheKeyName))
            {
                return cache[cacheKeyName] as Object;
            }
            else
            {
                return null;
            }

        }

        public void RemoveDataCachedItem(string cacheKeyName)
        {
            if (cache.Contains(cacheKeyName))
            {
                cache.Remove(cacheKeyName);
            }
        }

        public bool IsItemCached(string cacheKeyName)
        {
            if (cache.Contains(cacheKeyName))
            {
                return true;
            }
            else
            {
                return false;
            }

        }
    }

    public enum CachePriority
    {
        Default,
        NotRemovable
    }

}
