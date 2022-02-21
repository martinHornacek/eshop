using eshop.Domain.Core;
using System;
using System.Collections.Generic;

namespace eshop.Infrastructure.Interfaces
{
    public interface IEventStore
    {
        void SaveEvents(Guid aggregateId, IEnumerable<Event> events, int expectedVersion);
        List<Event> GetEventsForAggregate(Guid aggregateId);
    }
}
