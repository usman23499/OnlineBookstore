

using OnlineBookstore.Report.Core;

namespace OnlineBookstore.Report.DataAccess
{
    public interface IUnitOfWork
    {
        IReportRepository Reports { get; }
        void Commit();
    }
}

