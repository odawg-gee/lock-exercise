using System;
using System.Runtime.Caching;
using LockSandbox.Services.Interfaces;

namespace LockSandbox.Services
{
    internal class CacheService : IDisposable, ICacheService
    {
        private readonly MemoryCache _memoryCach;

        public CacheService()
        {
            _memoryCach = new MemoryCache("TestCache");
        }

        public void SetCache<TData>(TData data, string key, long seconds)
        {
            _memoryCach.Add(key, data, DateTimeOffset.Now.AddSeconds(seconds));
        }

        public TData GetCache<TData>(string key)
        {
            return (TData) _memoryCach.GetCacheItem(key)?.Value;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                _memoryCach?.Dispose();
            }
        }
    }
}