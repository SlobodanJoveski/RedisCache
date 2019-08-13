using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using RedisCache.Models;
using RedisCache.Services;

namespace RedisCache.Controllers
{
    // home controller
    public class HomeController : Controller
    {
        private readonly IRedisService _redisService;

        public HomeController(IRedisService redisService)
        {
            _redisService = redisService;
        }

        public IActionResult Index()
        {
            // save a string value to redis
            string stringKey = "TestString";
            _redisService.SetStringWithTime(stringKey, "my string value");

            // save an object to redis
            string userKey = "TestUser";
            _redisService.SetUser(userKey);
            var user = _redisService.GetUser(userKey);

            // get values
            ViewBag.TestRedis = _redisService.GetString(stringKey);
            ViewBag.User = $"{user.Email} created at {user.Created}";
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
