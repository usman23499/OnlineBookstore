using System;
using System.Collections.Generic;

namespace OnlineBookStore.User.DataAccess.DAO
{
    public class RoleDAO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public List<UserRoleDAO> UserRoles { get; set; }
    }
}
