using Microsoft.EntityFrameworkCore;
using OnlineBook.Book.DataAccess;
using OnlineBookstore.Core;
using OnlineBookstore.DataAccess.DAO;

namespace OnlineBookstore.DataAccess
{
    public class OrderRepository : IOrderRepository
    {
        private readonly BookDBContext context;
        public OrderRepository(BookDBContext bookDBContext)
        {
                context = bookDBContext;
        }        
        public Task<Order> Add(Order order)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Order>> GetAll()
        {
            List<OrderDAO> order = await context.Orders.ToListAsync();
            List<Order> orders = order
                .Select(orderDAO => Order.Create(orderDAO.Id, orderDAO.OrderDate, orderDAO.Quantity))
                .ToList();

            return orders;
        }

        public async Task<Order> GetById(Guid id)
        {
            OrderDAO order = await context.Orders.FindAsync(id);

            return Order.Create(order.Id, order.OrderDate, order.Quantity);
        }

        public Task<Order> Update(Order order)
        {
            throw new NotImplementedException();
        }
    }
}
