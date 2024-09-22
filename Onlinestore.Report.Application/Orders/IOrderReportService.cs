//using System;
//using System.Collections.Generic;
//using System.IO;
//using System.Threading.Tasks;

//namespace OnlineBookstore.Report.Application
//{
//    public interface IOrderReportService
//    {
//       public Task<string> GetReport(DateTime fromDate, DateTime toDate, string folderName, string fileName);
//       public Task<Report> CreateReport(ServiceReportDto serviceReport);
//       public Task<Report> UpdateReport(ServiceReportDto serviceReport);
//       public Task<List<Report>> GetWeeklyMonthlyReports(ReportType reportType, int year);
//    }
//}