using Microsoft.EntityFrameworkCore;
using OnlineBookstore.DataAccess.DAO;
using OnlineBookstore.DataAccess.User.DAO;

namespace OnlineBook.Book.DataAccess
{
    public class BookDBContext: DbContext
    {
        public BookDBContext(DbContextOptions<BookDBContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<BookDAO>().OwnsOne(b => b.Price);
               
        }
        public DbSet<BookDAO> Books { get; set; }
        public DbSet<OrderDAO> Orders { get; set; }
        public DbSet<UserDAO> Users { get; set; }
        public DbSet<RoleDAO> Roles { get; set; }
    }
}
