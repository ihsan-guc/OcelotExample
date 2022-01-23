using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppOne.Model
{
    public class UserDTO
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Description { get; set; }
    }
    public class User
    {
        public int Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Description { get; set; }
    }
    public static class UserModel
    {
        public static List<User> userList = new List<User>();
    }
}
