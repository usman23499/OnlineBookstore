using AutoMapper;
using OnlineBookstore.Core;
using OnlineBookstore.Core.User;
using OnlineBookstore.DataAccess.DAO;
using OnlineBookstore.DataAccess.User.DAO;

namespace OnlineBookstore.DataAccess.Mapping
{
    public class BookProfile: Profile
    {
        public BookProfile()
        {
            CreateMap<Core.Book,  BookDAO>  ();
            CreateMap<Order, OrderDAO> ();
            CreateMap<Price, PriceDAO> ();
            CreateMap<Core.User.User, UserDAO>();
            CreateMap<Core.User.Role, RoleDAO>();
            CreateMap<Core.User.UserRole, UserRoleDAO>();
        }
    }
}
