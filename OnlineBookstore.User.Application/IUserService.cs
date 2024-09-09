using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineBookstore.User.Application.User
{
    public interface IUserService
    {
        Task<UserRM> Login(string username, string password);
        Task<Core.User.User> Register(UserDTO user);
        Task<RoleRM> AddRole(string roleName);
    }
}
