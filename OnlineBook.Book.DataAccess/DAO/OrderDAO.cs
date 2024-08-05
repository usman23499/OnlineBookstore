using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineBook.Book.DataAccess.DAO
{
    public class OrderDAO
    {
        public Guid Id { get; set; }
        public DateTime OrderDate { get; set; }
        public int Quantity { get; set; }
        public BookDAO Book { get; set; }
    }
}
