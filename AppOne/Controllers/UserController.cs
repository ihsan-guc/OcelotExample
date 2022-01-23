using AppOne.Model;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace AppOne.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        List<User> userList = UserModel.userList;

        [HttpGet]
        [Route("GetUser")]
        public IActionResult GetUser(int id)
        {
            return Ok(userList.FirstOrDefault(p => p.Id == id));
        }
        [HttpGet]
        [Route("GetUserList")]
        public IActionResult GetUserList()
        {
            return Ok(userList);
        }
        [HttpPost]
        [Route("AddUser")]
        public IActionResult AddUser(UserDTO userDTO)
        {
            var user = new User()
            {
                Description = userDTO.Description,
                Firstname = userDTO.Firstname,
                Lastname = userDTO.Lastname,
                Id = userList.Count()
            };
            userList.Add(user);
            return Ok(userList);
        }
    }
}
