using System;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;

namespace RedisCache.Data
{
    public class RedisRepository : IRedisRepository
    {
        private readonly IDistributedCache _cache;

        public RedisRepository(IDistributedCache cache)
        {
            _cache = cache;
        }
        public string GetString(string key)
        {
            return _cache.GetString(key);
        }

        public void SetString(string key, string value)
        {
            _cache.SetString(key, value);
        }

        public void SetObject<T>(string key, T value)
        {
            var jsonObject = JsonConvert.SerializeObject(value);
            _cache.SetString(key, jsonObject);
        }

        public T GetObject<T>(string key)
        {
            var res = _cache.GetString(key);
            return JsonConvert.DeserializeObject<T>(res);
        }

        public void SetWithExpiration(string key, string value, int expiresIn)
        {
            DistributedCacheEntryOptions options = new DistributedCacheEntryOptions
            {
                AbsoluteExpirationRelativeToNow = new TimeSpan(0, 0, expiresIn)
            };
            _cache.SetString(key, value, options);
        }
    }
}
