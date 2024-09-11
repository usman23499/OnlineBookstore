using OnlineBookStore.User.Core;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OnlineBookstore.User.Application
{
    public interface IUserService
    {
        Task<UserRM> Login(string username, string password);
        Task<OnlineBookStore.User.Core.User> Register(Dto.UserDTO user);
        Task<RoleRM> AddRole(string roleName);
    }
}
