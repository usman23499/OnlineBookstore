using AutoMapper;
using OnlineBookstore.Book.Core;
using OnlineBookstore.Book.DataAccess.DAO;

namespace OnlineBookstore.DataAccess.Mapping
{
    public class BookProfile : Profile
    {
        public BookProfile()
        {
            CreateMap<Book.Core.Book, BookDAO>();
            CreateMap<Order, OrderDAO>();
            CreateMap<Price, PriceDAO>();
        }
    }
}
