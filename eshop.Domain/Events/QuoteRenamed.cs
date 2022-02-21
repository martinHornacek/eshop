using eshop.Domain.Core;
using System;

namespace eshop.Domain.Events
{
    public class QuoteRenamed : Event
    {
        public readonly Guid Id;
        public readonly string NewName;

        public QuoteRenamed(Guid id, string newName)
        {
            Id = id;
            NewName = newName;
        }
    }
}
