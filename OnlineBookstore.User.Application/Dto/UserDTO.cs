using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OnlineBookstore.User.Application.Dto
{
    public class UserDTO
    {
        public string Name { get;  set; }
        public string Email { get;  set; }
        public string Password { get;  set; }
        public List<string> UserRoleName { get; set; }
    }
}
