namespace OnlineBookstore.Core.User
{
    public interface IUserRepository
    {
        Task<UserRM> Login(string username, string password);
        Task Register(User user);
        Task<RoleRM> AddRole(UserRole role);

    }
}
