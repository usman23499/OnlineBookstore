using System;

namespace OnlineBookStore.Common.Core
{
    public class Audit : ValueObject
    {
        private Audit(DateTime createdOn, string createdBy, DateTime updatedOn, string updatedBy)
        {
            CreatedOn = createdOn;
            CreatedBy = createdBy;
            UpdatedOn = updatedOn;
            UpdatedBy = updatedBy;
        }

        public DateTime CreatedOn { get; private set; }
        public string CreatedBy { get; private set; }
        public DateTime UpdatedOn { get; private set; }
        public string UpdatedBy { get; private set; }

        public static Audit Create(DateTime createdOn, string createdBy, DateTime updatedOn, string updatedBy)
        {
            Audit audit = new Audit(createdOn, createdBy, updatedOn, updatedBy);

            if (createdOn == null) throw new ArgumentNullException(nameof(createdOn));
            if (createdBy == null) throw new ArgumentNullException(nameof(createdBy));
            if (updatedOn == null) throw new ArgumentNullException(nameof(updatedOn));
            if (updatedBy == null) throw new ArgumentNullException(nameof(updatedBy));

            return audit;
        }
    }
}