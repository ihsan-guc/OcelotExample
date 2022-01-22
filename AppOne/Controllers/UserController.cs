using AppOne.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;

namespace AppOne.Controllers
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
            return Ok();
        }
        [HttpPost]
        [Route("AddUser")]
        public IActionResult AddUser(List<UserDTO> userDTO)
        {
            _memoryCache.Set(usersKey, userDTO, new MemoryCacheEntryOptions
            {
                AbsoluteExpiration = DateTime.Now.AddDays(1),
                Priority = CacheItemPriority.Normal
            });
            return Ok(userDTO);
        }
        [HttpDelete]
        [Route("RemoveUser")]
        public IActionResult RemoveUser()
        {
            _memoryCache.Remove(usersKey);
            return Ok();
        }
    }
}
