using OnlineBookstore.Core.User;

namespace OnlineBookstore.DataAccess.User
{
    public class UserRepository : IUserRepository
    {
        public Task<UserRM> Login(string username, string password)
        {
            throw new NotImplementedException();
        }

        public Task Register(Core.User.User user)
        {
            throw new NotImplementedException();
        }
        public Task<RoleRM> AddRole(UserRole role)
        {
            throw new NotImplementedException();
        }
    }
}
