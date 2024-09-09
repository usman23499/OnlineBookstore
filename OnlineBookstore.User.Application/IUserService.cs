using OnlineBookstore.Application.User.Dto;
using OnlineBookstore.User.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineBookstore.User.Application
{
    public interface IUserService
    {
        Task<UserRM> Login(string username, string password);
        Task<Core.User> Register(UserDTO user);
        Task<RoleRM> AddRole(string roleName);
    }
}
