using System;

namespace OnlineBookStore.Common.Core
{
    public class Entity<TPrimaryKey>
    {
        public TPrimaryKey Id { get; protected set; }
        public int PersistentId { get; protected set; }
        public bool IsDeleted { get; protected set; }
        public DateTime CreatedOn { get; private set; }
        public string CreatedBy { get; private set; }
        public DateTime UpdatedOn { get; private set; }
        public string UpdatedBy { get; private set; }

        public void CreateAudit(string createdBy)
        {
            CreatedOn = DateTime.Now;
            CreatedBy = createdBy;
            UpdatedOn = DateTime.Now;
            UpdatedBy = createdBy;
        }

        public void UpdateAudit(string updatedBy)
        {
            UpdatedOn = DateTime.Now;
            UpdatedBy = updatedBy;
        }

        public void UpdateDeleteAudit(string deletedBy)
        {
            UpdatedOn = DateTime.Now;
            UpdatedBy = deletedBy;
        }

        public void SetAudit(DateTime createdOn, string createdBy, DateTime updatedOn, string updatedBy)
        {
            CreatedOn = createdOn;
            CreatedBy = createdBy;
            UpdatedOn = updatedOn;
            UpdatedBy = updatedBy;
        }
    }
}