using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineBookstore.Book.Application.Dto;
using OnlineBookstore.Book.Core;

namespace OnlineBookstore.Book.Application
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

        public async Task<Core.Book> AddBook(AddBookDto dto)
        {
            Core.Book book = Core.Book.Create(dto.Title, dto.Author, dto.Discription);
            Price price = Price.Create(dto.Amount, dto.Currency);
            book.SetPrice(price);
            Core.Book bookReturn = await _bookRepository.Add(book);
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
            Core.Book book = await _bookRepository.GetById(dto.BookId);
            Order order = Order.Create(dto.Quantity, book.Id);
            Order orderReturn = await _orderRepository.Add(order);

            return orderReturn;
        }
    }
}
