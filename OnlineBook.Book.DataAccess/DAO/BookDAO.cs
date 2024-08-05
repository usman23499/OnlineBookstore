using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineBook.Book.DataAccess.DAO
{
    public class BookDAO
    {
        public Guid Id { get;  set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public PriceDAO Price { get; set; }
        public string? Discription { get; set; }
        public List<OrderDAO> orders { get; private set; }
    }
}
