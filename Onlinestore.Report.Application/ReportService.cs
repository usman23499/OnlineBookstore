using OnlineBookstore.Report.Core;
using OnlineBookstore.Report.DataAccess;
using System;


namespace OnlineBookstore.Report.Application
{
    public class ReportService : IReportService
    {
        private readonly IUnitOfWork _unitOfWork;
        public ReportService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public bool CheckIfLogExists(DateTime dateFrom, DateTime dateTo)
        {
            ReportLog reportLog = _unitOfWork.Reports.Get(dateFrom, dateTo);
            if (reportLog == null)
                return false;
            return true;
        }

        public void Add(ReportLogDto reportLogDto)
        {
            ReportLog reportLog = ReportLog.Create(reportLogDto.DateFrom,
            reportLogDto.DateTo,
            reportLogDto.Title,
            reportLogDto.Url);

            _unitOfWork.Reports.Add(reportLog);
            _unitOfWork.Commit();
        }

        public void Update(DateTime dateFrom, DateTime dateTo, string url)
        {
            ReportLog reportLog = _unitOfWork.Reports.Get(dateFrom, dateTo);
            
            reportLog.Update(url);
            _unitOfWork.Reports.Update(reportLog);
            _unitOfWork.Commit();
        }
    }
}
