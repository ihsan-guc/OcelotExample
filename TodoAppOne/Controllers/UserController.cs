using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using System;
using TodoAppOne.Model;

namespace TodoAppOne.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        IMemoryCache _memoryCache;
        const string usersKey = "users";

        public UserController(IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;
        }

        [HttpGet]
        [Route("GetUserList")]
        public IActionResult GetUserList()
        {
            if (_memoryCache.TryGetValue(usersKey, out object list))
                return Ok(list);
            return null;
        }
        [HttpPost]
        [Route("AddUser")]
        public IActionResult AddUser(UserDTO userDTO)
        {
            _memoryCache.Set(usersKey, userDTO, new MemoryCacheEntryOptions
            {
                AbsoluteExpiration = DateTime.Now.AddSeconds(20),
                Priority = CacheItemPriority.Normal
            });
            return Ok(userDTO);
        }
        [HttpPost]
        [Route("RemoveUser")]
        public IActionResult RemoveUser(UserDTO userDTO)
        {
            _memoryCache.Remove(usersKey);
            return Ok();
        }
    }
}
