using OnlineBookstore.Core;

namespace OnlineBookstore.Application
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepository;
        private readonly IOrderRepository _orderRepository;
        public BookService(IBookRepository bookRepository, IOrderRepository orderRepository)
        {
            _bookRepository = bookRepository;
            _orderRepository = orderRepository;
        }
        public async Task<Order> GetOrderById(Guid id)
        {
            return await _orderRepository.GetById(id);
        }

        public async Task<List<Order>> GetOrdersAll()
        {
            return await _orderRepository.GetAll();
        }
    }
}
