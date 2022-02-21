using eshop.Domain.Core;
using System;

namespace eshop.Domain.Commands
{
    public class AddQuoteProductsToQuote: Command
    {
        public Guid QuoteId;
        public readonly int Count;
        public readonly int OriginalVersion;

        public AddQuoteProductsToQuote(Guid quoteId, int count, int originalVersion)
        {
            QuoteId = quoteId;
            Count = count;
            OriginalVersion = originalVersion;
        }
    }
}
