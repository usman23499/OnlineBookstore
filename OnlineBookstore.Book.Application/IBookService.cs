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
    public interface IBookService
    {
        Task<Order> GetOrderById(Guid id);
        Task<List<Order>> GetOrdersAll();
        Task<Core.Book> AddBook(AddBookDto dto);
        Task<Order> CreateOrder(CreateOrderDto dto);
    }
}
