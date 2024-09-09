using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineBookstore.User.DataAccess
{
    public class UserRoleDAO
    {
        public Guid UserId { get; set; }
        public virtual UserDAO User { get; set; }
        public Guid RoleId { get; set; }
        public virtual RoleDAO Role { get; set; }
    }
}
