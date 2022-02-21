using eshop.Domain.Core;
using System;

namespace eshop.Domain.Events
{
    public class QuoteProductsAddedToQuote : Event
    {
        public Guid Id;
        public readonly int Count;

        public QuoteProductsAddedToQuote(Guid id, int count)
        {
            Id = id;
            Count = count;
        }
    }
}
