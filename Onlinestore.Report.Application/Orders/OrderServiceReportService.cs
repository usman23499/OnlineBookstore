//using System;
//using System.Collections.Generic;
//using System.IO;
//using System.Linq;
//using System.Threading.Tasks;


//namespace OnlineBookstore.Report.Application
//{
//    public class OrderServiceReportService : IOrderReportService
//    {
//        private readonly IUnitOfWork _unitOfWork;
//        private readonly IExcelSpreedSheetGenerationService _excelSpreedSheetGenerationService;
//        private readonly IAWSAmazonS3Utility _iAWSAmazonS3Utility;
//        private readonly IReportService _reportService;
//        private readonly string S3SiteFolder = "Reports";

//        public OrderServiceReportService(IUnitOfWork unitOfWork,
//            IMapper mapper,
//            IExcelSpreedSheetGenerationService excelSpreedSheetGenerationService,
//            IReportService reportService,
//            IAWSAmazonS3Utility iAWSAmazonS3Utility)
//        {
//            _unitOfWork = unitOfWork;
//            _excelSpreedSheetGenerationService = excelSpreedSheetGenerationService;
//            _reportService = reportService;
//            _iAWSAmazonS3Utility = iAWSAmazonS3Utility;
//        }

//        public async Task<string> GetReport(DateTime fromDate, DateTime toDate, string folderName, string fileName)
//        {
//            List<OrderServiceReport> weeklyReports = await _unitOfWork.OrderServiceReport.GetReport(fromDate,toDate);
//            List<OrderServiceReportDto> weeklyReportDto = new List<OrderServiceReportDto>();
            
//            weeklyReports
//                .ForEach(weeklyReport =>
//                weeklyReportDto.Add(new OrderServiceReportDto()
//                {
//                    DateRequested = weeklyReport.DateRequested.ToString("d"),
//                    RequiredOn = weeklyReport.RequiredOn.ToString("d"),
//                    DateCompleted = weeklyReport.DateCompleted.ToString("d"),
//                    ServiceNumber = weeklyReport.ServiceNumber,
//                    ServiceDescription = weeklyReport.ServiceDescription,
//                    Abbreviation = weeklyReport.Abbreviation,
//                    QuantityRemoved = weeklyReport.QuantityRemoved,
//                    TonnageRemoved = weeklyReport.TonnageRemoved,
//                    Hours = weeklyReport.Hours,
//                    ClientInvoice = $"${weeklyReport.ClientInvoice}",
//                    ContractorCalculatedAmount = $"${weeklyReport.ContractorCalculatedAmount}",
//                    ApprovedAmount = $"${weeklyReport.ApprovedAmount}",
//                    Vehicle = weeklyReport.Vehicle,
//                    Operator = weeklyReport.Operator,
//                    Client = weeklyReport.Client,
//                    StreetAddress = weeklyReport.StreetAddress,
//                    Suburb = weeklyReport.Suburb,
//                    PostCode = weeklyReport.PostCode,
//                    ServiceHistoryNotes = weeklyReport.ServiceHistoryNotes,
//                    InstructionsToDriver = weeklyReport.InstructionsToDriver,
//                }
//                ));

//            var reportStream = _excelSpreedSheetGenerationService.CreateExcelSpreedSheet(weeklyReportDto);
//            var fileUrl = UploadExcelFile(folderName, fileName, reportStream);
//            // here add service

//            return fileUrl;
//        }

//        public async Task<_Report> CreateReport(ServiceReportDto command)
//        {
//            string folderName = (Enum.GetName(typeof(ReportType), command.ReportType));
//            string fileName = $"{Enum.GetName(typeof(ReportType), command.ReportType)}-{command.DateFrom:dd-MM-yyyy}_{command.DateTo:dd-MM-yyyy}";
//            var orderServiceReportUrl = await GetReport(command.DateFrom, command.DateTo, folderName, fileName);

//            _reportService.Add(new ReportLogDto() 
//            { 
//                DateFrom = command.DateFrom,
//                DateTo   = command.DateTo,
//                Title    = fileName,
//                Url      = orderServiceReportUrl
//            });

//            return new _Report()
//            {
//                No          = command.No,
//                GeneratedOn = DateTime.Now,
//                FromDate    = command.DateFrom,
//                ToDate      = command.DateTo,
//                Url         = orderServiceReportUrl,
//                Month       = command.DateTo.ToString("MMMM"),
//            };
//        }
//        public async Task<_Report> UpdateReport(ServiceReportDto command)
//        {
//            string folderName = (Enum.GetName(typeof(ReportType), command.ReportType));
//            string fileName = $"{Enum.GetName(typeof(ReportType), command.ReportType)}-{command.DateFrom:dd-MM-yyyy}_{command.DateTo:dd-MM-yyyy}";
//            var orderServiceReportUrl = await GetReport(command.DateFrom, command.DateTo, folderName, fileName);

//            _reportService.Update(command.DateFrom, command.DateTo, orderServiceReportUrl);
            
//            return new _Report()
//            {
//                No          = command.No,
//                GeneratedOn = DateTime.Now,
//                FromDate    = command.DateFrom,
//                ToDate      = command.DateTo,
//                Url         = orderServiceReportUrl,
//                Month       = command.DateTo.ToString("MMMM"),
//            };
//        }
//        public async Task<List<_Report>> GetWeeklyMonthlyReports(ReportType reportType, int year)
//        {
//            List<_Report> reportsData = reportType == ReportType.ServicesWeeklyReport ? GetWeeksData(year) : GetMonthsData(year);

//            if (reportsData.Count > 0)
//            {
//                List<ReportLog> reportSavedData = _unitOfWork.Reports.GetAll(reportType, reportsData[0].FromDate, reportsData[reportsData.Count - 1].ToDate);

//                if (reportSavedData.Count > 0)
//                    foreach (_Report report in reportsData)
//                    {
//                        ReportLog findReport = reportSavedData
//                            .FirstOrDefault(x => x.DateFrom == report.FromDate && x.DateTo == report.ToDate);
//                        if(findReport != null)
//                        {
//                            report.Url = findReport.Url;
//                            report.GeneratedOn = findReport.UpdatedOn;
//                        }
//                    }
//            }
//            else
//            {
//                throw new Exception();
//            }

//            return reportsData;
//        }

//        private List<_Report> GetWeeksData(int year)
//        {
//            DateTime jan1 = new DateTime(year, 01, 01);
//            DateTime startOfFirstWeek = jan1.AddDays(1 - (int)(jan1.DayOfWeek));
//            var weeks =
//                Enumerable
//                    .Range(0, 54)
//                    .Select(i => new
//                    {
//                        weekStart = startOfFirstWeek.AddDays(i * 7)
//                    })
//                    .TakeWhile(x => x.weekStart.Year <= jan1.Year)
//                    .TakeWhile(x => x.weekStart.Date <= DateTime.Now.Date)
//                    .Select(x => new
//                    {
//                        x.weekStart,
//                        weekFinish = x.weekStart.AddDays(6)
//                    })
//                    .SkipWhile(x => x.weekFinish.Year < jan1.Year)
//                    .Select((x, i) => new _Report()
//                    {
//                        FromDate = x.weekStart,
//                        ToDate = x.weekFinish,
//                        No = i + 1,
//                        Month = x.weekFinish.ToString("MMMM"),
//                    }
//                    );

//            return weeks.ToList();
//        }

//        public List<_Report> GetMonthsData(int year)
//        {
//            DateTime start = new DateTime(year, 01, 01);
//            DateTime end = new DateTime(year, 12, 31);
//            List<_Report> reports = new List<_Report>();

//            while (start < end)
//            {
//                if (start.Year >= DateTime.Now.Year && start.Month > DateTime.Now.Month)
//                    break;
//                var lastDayOfMonth = DateTime.DaysInMonth(start.Year, start.Month);
//                var howManyDays = lastDayOfMonth - start.Day;
//                var monthEndDate = start.AddDays(howManyDays);
//                reports.Add(new _Report()
//                {
//                    FromDate = start,
//                    ToDate = monthEndDate,
//                    No = start.Month,
//                    Month = start.ToString("MMMM"),
//                });
//                start = monthEndDate.AddDays(1);
//            }

//            return reports;
//        }
//        private string UploadExcelFile(string folderName, string fileName, Stream stream)
//        {
//            var filePath = Path.Combine(S3SiteFolder, folderName.ToString());
//            var baseUrl = _iAWSAmazonS3Utility.UploadFile(fileName, filePath, stream, FileContentType.ExcelFileContentType);
//            var fileUrl = Path.Combine(baseUrl,S3SiteFolder,folderName, fileName);
//            fileUrl = fileUrl.Replace("\\","/");
//            return fileUrl;
//        }

//    }
//}
