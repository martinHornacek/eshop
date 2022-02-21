using eshop.Domain.Core;
using System;

namespace eshop.Domain.Commands
{
    public class CreateQuote : Command
    {
        public readonly Guid QuoteId;
        public readonly string Name;

        public CreateQuote(Guid quoteId, string name)
        {
            QuoteId = quoteId;
            Name = name;
        }
    }
}
