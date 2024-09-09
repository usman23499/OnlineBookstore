using AutoMapper;
using OnlineBookstore.DataAccess.User.DAO;

namespace OnlineBookstore.DataAccess.Mapping
{
    public class BookProfile: Profile
    {
        public BookProfile()
        {
            CreateMap<User, UserDAO>();
            CreateMap<Role, RoleDAO>();
            CreateMap<UserRole, UserRoleDAO>();
        }
    }
}
