namespace RedisCache.Data
{
    public interface IRedisRepository
    {
        string GetString(string key);

        void SetString(string key, string value);

        void SetObject<T>(string key, T value);

        T GetObject<T>(string key);
    }
}
