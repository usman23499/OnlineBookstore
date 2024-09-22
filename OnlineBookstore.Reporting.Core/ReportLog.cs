using OnlineBookStore.Common.Core;
using System;


namespace OnlineBookstore.Report.Core
{
    public class ReportLog : Entity<Guid>
    {
        public DateTime DateFrom { get; private set; }
        public DateTime DateTo { get; private set; }
        public string Title { get; private set; }
        public string Url { get; private set; }

        private ReportLog(
            Guid id,
            DateTime dateFrom,
            DateTime dateTo,
            string title,
            string url)
        {
            Id = id;
            DateFrom = dateFrom;
            DateTo = dateTo;
            Title = title;
            Url = url;
        }
        private ReportLog(
         Guid id,
         DateTime dateFrom,
         DateTime dateTo,
         string title,
         string url,
         DateTime createdOn,
         string createdBy,
         DateTime updatedOn,
         string updatedBy)
        {
            Id = id;
            DateFrom = dateFrom;
            DateTo = dateTo;
            Title = title;
            Url = url;
            SetAudit(createdOn, createdBy, updatedOn, updatedBy);
        }
        public static ReportLog Create(
            DateTime dateFrom,
            DateTime dateTo,
            string title,
            string url)
        {
            validate(dateFrom, dateTo);

            return new ReportLog(
                Guid.NewGuid(),
                dateFrom,
                dateTo,
                title,
                url);
        }
        public static ReportLog Create(
            DateTime dateFrom,
            DateTime dateTo,
            string title,
            string url,
            Audit audit)
        {
            validate(dateFrom, dateTo);

            return new ReportLog(
                Guid.NewGuid(),
                dateFrom,
                dateTo,
                title,
                url,
                audit.CreatedOn,
                audit.CreatedBy,
                audit.UpdatedOn,
                audit.UpdatedBy
                );
        }

        public void Update(string url)
        {
            Url = url;
        }
        private static void validate(DateTime dateFrom, DateTime dateTo)
        {
            if (dateFrom > dateTo)
            {
                throw new Exception("Incorrect Dates");
            }

        }
    }
}
