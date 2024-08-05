using Microsoft.EntityFrameworkCore;
using OnlineBook.Book.DataAccess.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineBook.Book.DataAccess
{
    public class BookDBContext: DbContext
    {
        public BookDBContext(DbContextOptions<BookDBContext> options) : base(options)
        {

        }

        public DbSet<BookDAO> Books { get; set; }
        public DbSet<OrderDAO> Orders { get; set; }
    }
}
