using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using OnlineBookStore.User.DataAccess;

namespace OnlineBookStore.User.DbMigration
{
    public class UserContextFactory : IDesignTimeDbContextFactory<UserDBContext>
    {
        public UserDBContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<UserDBContext>();
            optionsBuilder.UseSqlServer("server=DESKTOP-3C82H0C;database=OnlineBookMicroService;Trusted_Connection=true;", sqlOption => sqlOption.MigrationsAssembly("OnlineBookStore.User.DbMigration"));
            return new UserDBContext(optionsBuilder.Options);
        }

    }
}

