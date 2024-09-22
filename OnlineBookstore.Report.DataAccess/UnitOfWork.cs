using Microsoft.EntityFrameworkCore;
using OnlineBookstore.Report.Core;
using OnlineBookStore.Common.DataAccess.DAO;
using System;

namespace OnlineBookstore.Report.DataAccess
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ReportContext _context;

        public UnitOfWork(ReportContext context)
        {
            _context = context;
            Reports = new ReportRepository(context);
        }
        public IReportRepository Reports { get; }
        public void Commit()
        {
            foreach (var entityEntry in _context.ChangeTracker.Entries())
            {
                if (entityEntry.State == EntityState.Modified)
                {
                    var entity = _context.Update((EntityDAO<Guid>)entityEntry.Entity);

                    entity.Property(x => x.UpdatedBy).CurrentValue = "UsmanUpdate@Gmail.com";
                    entity.Property(x => x.UpdatedOn).CurrentValue = DateTime.Now;

                    entity.Property(x => x.PersistentId).IsModified = false;
                }

                if (entityEntry.State == EntityState.Added)
                {
                    var entity = _context.Add((EntityDAO<Guid>)entityEntry.Entity);

                    entity.Property(x => x.CreatedBy).CurrentValue = "UsmanADD@Gmail.com";
                    entity.Property(x => x.CreatedOn).CurrentValue = DateTime.Now;

                    entity.Property(x => x.UpdatedBy).CurrentValue = "UsmanADDUpdate@Gmail.com";
                    entity.Property(x => x.UpdatedOn).CurrentValue = DateTime.Now;
                }
            }
            _context.SaveChanges();
        }
    }
}

