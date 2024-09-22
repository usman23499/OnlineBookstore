using System;

namespace OnlineBookStore.Common.Core
{
    public interface IIntegrationEvent
    {
        public Guid CorrelationId { get; }
    }
}