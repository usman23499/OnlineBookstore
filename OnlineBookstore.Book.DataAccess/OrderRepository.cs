using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using OnlineBook.Book.DataAccess;
using OnlineBookstore.Book.Core;
using OnlineBookstore.Book.DataAccess.DAO;

namespace OnlineBookstore.Book.DataAccess
{
    public class OrderRepository : IOrderRepository
    {
        private readonly BookDBContext context;
        private readonly IMapper _mapper;

        public OrderRepository(BookDBContext bookDBContext, IMapper mapper)
        {
            context = bookDBContext;
            _mapper = mapper;
        }
        public async Task<Order> Add(Order order)
        {
            OrderDAO orderDAO = _mapper.Map<OrderDAO>(order);

            await context.Orders.AddAsync(orderDAO);
            await context.SaveChangesAsync();

            return order;
        }

        public async Task<List<Order>> GetAll()
        {
            List<OrderDAO> order = await context.Orders.ToListAsync();
            List<Order> orders = order
                .Select(orderDAO => Order.Create(orderDAO.Id, orderDAO.OrderDate, orderDAO.Quantity, orderDAO.BookId))
                .ToList();

            return orders;
        }

        public async Task<Order> GetById(Guid id)
        {
            OrderDAO order = await context.Orders.FindAsync(id);

            return Order.Create(order.Id, order.OrderDate, order.Quantity, order.BookId);
        }

        public Task<Order> Update(Order order)
        {
            throw new NotImplementedException();
        }
    }
}
