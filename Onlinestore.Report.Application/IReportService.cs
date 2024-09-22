using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OnlineBookstore.Report.Application
{
    public interface IReportService
    {
        bool CheckIfLogExists(DateTime dateFrom, DateTime dateTo);
        void Add(ReportLogDto reportLogDto);
        void Update(DateTime dateFrom, DateTime dateTo, string url);
    }
}
