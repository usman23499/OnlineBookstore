using AutoMapper;
using OnlineBookstore.Book.Core;
using OnlineBookstore.Book.DataAccess.DAO;

namespace OnlineBookstore.Book.DataAccess.Mapping
{
    public class BookProfile : Profile
    {
        public BookProfile()
        {
            CreateMap<Core.Book, BookDAO>();
            CreateMap<Order, OrderDAO>();
            CreateMap<Price, PriceDAO>();
        }
    }
}
