using OnlineBookstore.Application.User.Dto;
using OnlineBookstore.Core.User;
using OnlineBookstore.DataAccess.User.DAO;

namespace OnlineBookstore.Application.User
{
    public interface IUserService
    {
        Task<UserRM> Login(string username, string password);
        Task<Core.User.User> Register(UserDTO user);
        Task<RoleRM> AddRole(string roleName);
    }
}
