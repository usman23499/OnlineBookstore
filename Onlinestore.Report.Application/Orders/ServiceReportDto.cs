using OnlineBookStore.Common.Core.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineBookstore.Report.Application
{
    public class ServiceReportDto
    {
        public int No { get; set; }
        public ReportType ReportType { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
    }
}
