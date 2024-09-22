using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineBookstore.Report.Application
{
    public class ReportLogDto
    {
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
        public string Title { get; set; }
        public string Url { get; set; }
    }
}
