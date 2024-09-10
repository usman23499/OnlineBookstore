using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineBookstore.Book.Core
{
    public interface IOrderRepository
    {
        Task<Order>       GetById(Guid id);
        Task<List<Order>> GetAll();
        Task<Order>       Add(Order order);
        Task<Order>       Update(Order order);
    }
}
