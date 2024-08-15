using OnlineBookstore.Core;

namespace OnlineBookstore.DataAccess
{
    public interface IUnitOfWork
    {
        IBookRepository BookService { get; }
        IOrderRepository OrderService { get; }
        void Commit();
    }
}
