using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineBookstore.Book.Core
{
    public class Book
    {
        public Guid Id { get; private set; }
        public string Title { get; private set; }
        public string Author { get; private set; }
        public string? Discription { get; private set; }
        public List<Order> Orders { get; private set; }
        public Price Price { get; private set; }

        private Book(Guid id, string title, string author, string? discription)
        {
            Id = id;
            Title = title;
            Author = author;
            Discription = discription;
            Orders = new List<Order>();
        }
        private Book(string title, string author, string? discription)
        {

            Id = Guid.NewGuid();
            Title = title;
            Author = author;
            Discription = discription;
            Orders = new List<Order>();
        }

        public static Book Create(string title, string author, string? discription)
        {
            //validate(price.Amount);
            return new Book(title,author,discription);
        }

        public static Book Create(Guid id,string title, string author, string? discription)
        {
            //validate(price.Amount);
            return new Book(id,title, author, discription);
        }

        public void AddOrder(Order order)
        {
            Orders.Add(order);
        }

        public void SetPrice(Price price)
        {
            Price = price;
        }
    }
}
