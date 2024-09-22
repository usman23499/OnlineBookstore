using OnlineBookStore.Common.DataAccess.DAO;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineBookstore.Report.DataAccess
{
    public class ReportLogDAO : EntityDAO<Guid>
    {
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
        public string Title { get; set; }
        public string Url { get; set; }
    }
}
