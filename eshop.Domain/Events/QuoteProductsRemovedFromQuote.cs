using eshop.Domain.Core;
using System;

namespace eshop.Domain.Events
{
    public class QuoteProductsRemovedFromQuote : Event
    {
        public Guid Id;
        public readonly int Count;

        public QuoteProductsRemovedFromQuote(Guid id, int count)
        {
            Id = id;
            Count = count;
        }
    }
}
