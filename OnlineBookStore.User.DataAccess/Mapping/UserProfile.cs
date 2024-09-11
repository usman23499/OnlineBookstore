using AutoMapper;
using OnlineBookStore.User.DataAccess.DAO;
using OnlineBookStore.User.Core;


namespace OnlineBookstore.User.DataAccess.Mapping
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<OnlineBookStore.User.Core.User, UserDAO>();
            CreateMap<Role, UserRoleDAO>();
            CreateMap<UserRole, RoleDAO>();
        }
    }
}
