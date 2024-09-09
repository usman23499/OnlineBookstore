using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineBookstore.User.DataAccess
{
    public class RoleDAO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public List<UserRoleDAO> UserRoles { get; set; }
    }
}
