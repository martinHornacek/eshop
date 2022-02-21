using eshop.Domain.Core;
using System;

namespace eshop.Domain.Events
{
    public class QuoteActivated : Event
    {
        public readonly Guid Id;

        public QuoteActivated(Guid id)
        {
            Id = id;
        }
    }
}
