using System;
using RedisCache.Data;
using RedisCache.Models;

namespace RedisCache.Services
{
    public class RedisService : IRedisService
    {
        private readonly IRedisRepository _repository;

        public RedisService(IRedisRepository repository)
        {
            _repository = repository;
        }

        public void SetStringWithTime(string key, string value)
        {
            _repository.SetString(key, $"{value} at {DateTime.Now}");
        }

        public string GetString(string key)
        {
            return _repository.GetString(key);
        }

        public void SetUser(string key)
        {
            User user = new User
            {
                Name = key,
                Email = $"{key}@user.com",
                Phone = @"+389123456",
                Created = DateTime.Now
            };
            _repository.SetObject(key, user);
        }

        public User GetUser(string key)
        {
            return _repository.GetObject<User>(key);
        }
    }
}
