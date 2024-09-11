using System;
using System.Collections.Generic;

namespace OnlineBookStore.User.DataAccess.DAO
{
    public class UserRoleDAO
    {
        public Guid UserId { get; set; }
        public virtual UserDAO User { get; set; }
        public Guid RoleId { get; set; }
        public virtual RoleDAO Role { get; set; }
    }
}
