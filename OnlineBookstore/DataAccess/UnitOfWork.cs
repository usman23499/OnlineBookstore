using AutoMapper;
using Microsoft.EntityFrameworkCore;
using OnlineBook.Book.DataAccess;
using OnlineBookstore.Core;

namespace OnlineBookstore.DataAccess
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly BookDBContext _context;
        public UnitOfWork(BookDBContext context, IMapper mapper)
        {
            _context = context;
            BookService = new BookRepository(context,mapper);
            OrderService = new OrderRepository(context, mapper);
        }
        public IBookRepository BookService { get; }

        public IOrderRepository OrderService { get; }

        public void Commit()
        {
            foreach (var entityEntry in _context.ChangeTracker.Entries())
            {
                if (entityEntry.Metadata.ClrType.BaseType != null && entityEntry.Metadata.ClrType.BaseType.IsGenericType
                    && entityEntry.Metadata.ClrType.BaseType.GetGenericTypeDefinition() == typeof(EntityDAO<>))
                {
                    if (entityEntry.State == EntityState.Modified)
                    {
                        var entity = _context.Update((EntityDAO<Guid>)entityEntry.Entity);

                        entity.Property(x => x.UpdatedBy).CurrentValue = _userSession.GetUsername();
                        entity.Property(x => x.UpdatedOn).CurrentValue = DateTime.Now;

                        entity.Property(x => x.PersistentId).IsModified = false;
                    }

                    if (entityEntry.State == EntityState.Added)
                    {
                        var entity = _context.Add((EntityDAO<Guid>)entityEntry.Entity);

                        entity.Property(x => x.CreatedBy).CurrentValue = _userSession.GetUsername() != "" ? _userSession.GetUsername() : "SYSTEM";
                        entity.Property(x => x.CreatedOn).CurrentValue = DateTime.Now;

                        entity.Property(x => x.UpdatedBy).CurrentValue = _userSession.GetUsername() != "" ? _userSession.GetUsername() : "SYSTEM";
                        entity.Property(x => x.UpdatedOn).CurrentValue = DateTime.Now;
                    }
                }
            }

            _context.SaveChanges();
        }
    }
}
