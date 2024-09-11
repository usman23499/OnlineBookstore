
using Microsoft.EntityFrameworkCore;
using OnlineBookStore.User.DataAccess.DAO;

namespace OnlineBookStore.User.DataAccess
{
    public class UserDBContext : DbContext
    {
        public UserDBContext(DbContextOptions<UserDBContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserRoleDAO>()
                .HasKey(userRole => new { userRole.UserId, userRole.RoleId });
        }

        public DbSet<UserDAO> Users { get; set; }
        public DbSet<RoleDAO> Roles { get; set; }
        public DbSet<UserRoleDAO> UserRoles { get; set; }
    }
}
