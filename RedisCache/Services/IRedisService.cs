using RedisCache.Models;

namespace RedisCache.Services
{
    public interface IRedisService
    {
        void SetStringWithTime(string key, string value);

        string GetString(string key);

        void SetUser(string key);

        User GetUser(string key);
    }
}