using OnlineBookStore.Common.Core;
using System;
using System.Collections.Generic;

namespace OnlineBookStore.Common.DataAccess.DAO
{
    public class EntityDAO<TKey>
    {
        public TKey Id { get; set; }
        public int PersistentId { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        public DateTime UpdatedOn { get; set; }
        public string UpdatedBy { get; set; }
        public ICollection<IDomainEvent> DomainEvents { get; set; }
        public ICollection<IIntegrationEvent> IntegrationEvents { get; set; }
    }
}