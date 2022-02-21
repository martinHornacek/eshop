using eshop.Domain.Core;
using System;

namespace eshop.Domain.Commands
{
    public class ActivateQuote : Command
    {
        public readonly Guid QuoteId;
        public readonly int OriginalVersion;

        public ActivateQuote(Guid quoteId, int originalVersion)
        {
            QuoteId = quoteId;
            OriginalVersion = originalVersion;
        }
    }
}
