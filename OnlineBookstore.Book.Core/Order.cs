using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineBookstore.Book.Core
{
    public class Order
    {
        public Guid Id { get; protected set; }
        public DateTime OrderDate { get; private set; }
        public int Quantity { get; private set; }
        public Guid BookId { get; protected set; }
        public Book Book { get; private set; }

        public Order(Guid id, DateTime orderDate, int quantity, Guid bookId)
        {
            Id = id;
            OrderDate = orderDate;
            Quantity = quantity;
            BookId = bookId;
        }

        private Order(int quantity, Guid bookId )
        {
            Id = Guid.NewGuid();
            OrderDate = DateTime.Now;
            Quantity = quantity;
            BookId = bookId;

        }

        public static Order Create(int quantity, Guid bookId) 
        { 
            return new Order(quantity, bookId);
        }

        public static Order Create(
            Guid id, 
            DateTime orderTime, 
            int quantity,
            Guid bookId
            )
        {
            return new Order(id,orderTime,quantity, bookId);
        }
    }
}
