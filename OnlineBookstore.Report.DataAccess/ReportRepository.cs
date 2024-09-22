using System;
using System.Collections.Generic;
using System.Linq;
using OnlineBookstore.Report.Core;
using OnlineBookStore.Common.Core;
using OnlineBookStore.Common.Core.Enums;

namespace OnlineBookstore.Report.DataAccess
{
    public class ReportRepository : IReportRepository
    {
        private readonly ReportContext _context;
        public ReportRepository(ReportContext context)
        {
            _context = context;
        }

        public void Add(ReportLog reportLog)
        {
            ReportLogDAO reportLogDAO = new ReportLogDAO()
            {
                Id = reportLog.Id,
                DateFrom = reportLog.DateFrom,
                DateTo = reportLog.DateTo,
                Title = reportLog.Title,
                Url = reportLog.Url,
                PersistentId = reportLog.PersistentId+1,
                IsDeleted = reportLog.IsDeleted,
                CreatedBy = reportLog.CreatedBy,
                CreatedOn = reportLog.CreatedOn,
                UpdatedBy = reportLog.UpdatedBy,
                UpdatedOn = reportLog.UpdatedOn,
            };
            _context.Add(reportLogDAO);
        }
        public ReportLog Get(DateTime dateFrom, DateTime dateTo)
        {
            ReportLogDAO reportLogDAO = _context.ReportLogs.FirstOrDefault(x => x.DateFrom.Date == dateFrom.Date && x.DateTo.Date == dateTo.Date);
            if (reportLogDAO == null)
                return null;
            return ReportLog.Create(
                reportLogDAO.DateFrom,
                reportLogDAO.DateTo,
                reportLogDAO.Title,
                reportLogDAO.Url,
                Audit.Create(reportLogDAO.CreatedOn, reportLogDAO.CreatedBy, reportLogDAO.UpdatedOn, reportLogDAO.UpdatedBy));
        }

        public List<ReportLog> GetAll(ReportType reportType, DateTime dateFrom, DateTime dateTo)
        {
            return _context
                .ReportLogs
                .Where(reportLog => reportLog.Title.StartsWith(Enum.GetName(typeof(ReportType), reportType)))
                .Where(reportLog => reportLog.DateFrom.Date >= dateFrom.Date && reportLog.DateTo.Date <= dateTo.Date)
                .Select(reportLog => ReportLog
                .Create(reportLog.DateFrom, 
                reportLog.DateTo, 
                reportLog.Title, 
                reportLog.Url,
                Audit.Create(reportLog.CreatedOn, reportLog.CreatedBy, reportLog.UpdatedOn, reportLog.UpdatedBy)))
                .ToList();
        }

        public void Update(ReportLog reportLog)
        {
            ReportLogDAO reportLogDAO = _context.ReportLogs.FirstOrDefault(x => x.DateFrom.Date == reportLog.DateFrom.Date && x.DateTo.Date == reportLog.DateTo.Date);
            reportLogDAO.Url          = reportLog.Url; 
        }
    }
}
