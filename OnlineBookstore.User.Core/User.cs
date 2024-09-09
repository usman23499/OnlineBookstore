using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineBookstore.User.Core
{
    public class User
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public string Email { get; private set; }
        public string Password { get; private set; }
        public List<UserRole> _UserRoles { get; private set; }
        private User(Guid id, string name, string email, string password)
        {
            Id = id;
            Name = name;
            Email = email;
            Password = password;
            _UserRoles = new List<UserRole>();
        }

        public static User Create(Guid id, string name, string email, string password)
        {
            User user = new (id, name, email, password);
            return user;
        }
        public static User Create(string name, string email, string password)
        {
            User user = new(Guid.NewGuid(), name, email, password);
            return user;
        }

        public void AddUserRole(Guid roleId)
        {
            UserRole userRole = UserRole.Create(Id, roleId);
            _UserRoles.Add(userRole);
        }

        public void AddUserRole(Guid roleId, string roleName)
        {
            UserRole userRole = UserRole.Create(Id, roleId, roleName);
            _UserRoles.Add(userRole);
        }
    }
}
