using Microsoft.EntityFrameworkCore;
using OnlineBookStore.Common.DataAccess.Configurations;

namespace OnlineBookstore.Report.DataAccess
{
    public class ReportContext : DbContext
    {
        public ReportContext(DbContextOptions<ReportContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyEntityDAOConfiguration();

        }
        public DbSet<ReportLogDAO> ReportLogs { get; set; }
    }
}

