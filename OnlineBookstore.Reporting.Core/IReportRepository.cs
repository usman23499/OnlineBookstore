using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using OnlineBookStore.Common.Core.Enums;

namespace OnlineBookstore.Report.Core
{
    public interface  IReportRepository
    {
        public void Add(ReportLog reportLog);
        public ReportLog Get(DateTime dateFrom, DateTime dateTo);
        public void Update(ReportLog reportLog);
        public List<ReportLog> GetAll(ReportType reportType, DateTime dateFrom, DateTime dateTo);
    }
}
