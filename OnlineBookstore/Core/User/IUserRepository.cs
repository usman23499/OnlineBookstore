namespace OnlineBookstore.Core.User
{
    public interface IUserRepository
    {
        Task<UserRM> Login(string username, string password);
        Task<User> Register(User user);
        Task<RoleRM> AddRole(Role role);
        Task<UserRole> AssignRole(UserRole role);
        Task<Role> GetRoleByName(string roleName);
        Task<User> GetUserByEmail(string email);
    }
}
