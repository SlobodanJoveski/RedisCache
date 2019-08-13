using System;

namespace RedisCache.Models
{
    public class User
    {
        public string Email { get; set; }

        public string Name { get; set; }

        public string Phone { get; set; }

        public DateTime Created { get; set; }
    }
}
