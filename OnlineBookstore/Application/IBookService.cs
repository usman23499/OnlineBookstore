using OnlineBookstore.Core;

namespace OnlineBookstore.Application
{
    public interface IBookService
    {
        Task<Order> GetOrderById(Guid id);
        Task<List<Order>> GetOrdersAll();
        Task<Book> AddBook(Guid id);
    }
}
