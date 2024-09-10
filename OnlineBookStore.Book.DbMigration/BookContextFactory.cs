using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using OnlineBook.Book.DataAccess;

namespace OnlineBookStore.Book.DbMigration
{
    public class BookContextFactory : IDesignTimeDbContextFactory<BookDBContext>
    {
        public BookDBContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<BookDBContext>();
            optionsBuilder.UseSqlServer("server=DESKTOP-3C82H0C;database=OnlineBookMicroService;Trusted_Connection=true;", sqlOption => sqlOption.MigrationsAssembly("OnlineBookStore.Book.DbMigration"));
            return new BookDBContext(optionsBuilder.Options);
        }
    }
}

