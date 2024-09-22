
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using OnlineBookstore.Report.DataAccess;

namespace OnlineBookstore.Report.DbMigration
{
    public class ReportContextFactory : IDesignTimeDbContextFactory<ReportContext>
    {
        public ReportContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ReportContext>();
            optionsBuilder.UseSqlServer("server=DESKTOP-3C82H0C;database=OnlineBookMicroService;Trusted_Connection=true;", sqlOption => sqlOption.MigrationsAssembly("OnlineBookstore.Report.DbMigration"));
            return new ReportContext(optionsBuilder.Options);
        }
    }
}

