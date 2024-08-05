using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineBook.Order.Core
{
    public class Order
    {
        public Guid Id { get; protected set; }
        public DateTime OrderDate { get; private set; }
        public int Quantity { get; private set; }
        public OnlineBook.Book.Core.Book Book { get; private set; }
    }
}
