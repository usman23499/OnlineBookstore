using OnlineBook.Order.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineBook.Book.Core
{
    public class Book
    {
        public Guid Id { get; private set; }
        public string Title { get; private set; }
        public string Author { get; private set; }
        public Price Price { get; private set; }
        public string? Discription { get; private set; }
        public List<OnlineBook.Order.Core.Order> orders { get; private set; }

    }

}
