using System;
using System.Collections.Generic;

namespace OnlineBookStore.User.DataAccess.DAO
{
    public class UserDAO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public virtual List<UserRoleDAO> UserRoles { get; set; }
    }
}
