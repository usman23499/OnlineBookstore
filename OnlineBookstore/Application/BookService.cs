using OnlineBookstore.Application.Dto;
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

        public async Task<Book> AddBook(AddBookDto dto)
        {
            Book book = Book.Create(dto.Title, dto.Author, dto.Discription);
            Price price = Price.Create(dto.Amount, dto.Currency);
            book.SetPrice(price);
            Book bookReturn = await _bookRepository.Add(book);
            return bookReturn;
        }

        public async Task<Order> GetOrderById(Guid id)
        {
            return await _orderRepository.GetById(id);
        }

        public async Task<List<Order>> GetOrdersAll()
        {
            return await _orderRepository.GetAll();
        }

        public async Task<Order> CreateOrder(CreateOrderDto dto)
        {
            Book book = Book.Create(dto.Title, dto.Author, dto.Discription);
            Price price = Price.Create(dto.Amount, dto.Currency);
            book.SetPrice(price);
            Book bookReturn = await _bookRepository.Add(book);
            return bookReturn;
        }
    }
}
