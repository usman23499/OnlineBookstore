using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineBookStore.User.Core
{
    public class UserRM
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Token { get;  set; }
        public List<string> Roles { get; set; }
    }
}
