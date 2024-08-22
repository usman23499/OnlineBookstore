using OnlineBookstore.Application.Dto;
using OnlineBookstore.Core;

namespace OnlineBookstore.Application.Book
{
    public interface IBookService
    {
        Task<Order> GetOrderById(Guid id);
        Task<List<Order>> GetOrdersAll();
        Task<Core.Book> AddBook(AddBookDto dto);
        Task<Order> CreateOrder(CreateOrderDto dto);
    }
}
