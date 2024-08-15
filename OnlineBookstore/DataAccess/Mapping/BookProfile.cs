using AutoMapper;
using OnlineBookstore.DataAccess.DAO;

namespace OnlineBookstore.DataAccess.Mapping
{
    public class BookProfile: Profile
    {
        public BookProfile()
        {
            CreateMap<Core.Book,  BookDAO>  ();
            CreateMap<Core.Order, OrderDAO> ();
            CreateMap<Core.Price, PriceDAO> ();
        }
    }
}
