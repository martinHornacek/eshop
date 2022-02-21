using eshop.Domain.Core;
using System;

namespace eshop.Domain.Events
{
    public class QuoteCreated : Event
    {
        public readonly Guid Id;
        public readonly string Name;
        public QuoteCreated(Guid id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
