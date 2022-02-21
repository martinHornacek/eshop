using eshop.Domain.Core;
using System;

namespace eshop.Domain.Commands
{
    public class RenameQuote : Command
    {
        public readonly Guid QuoteId;
        public readonly string NewName;
        public readonly int OriginalVersion;

        public RenameQuote(Guid quoteId, string newName, int originalVersion)
        {
            QuoteId = quoteId;
            NewName = newName;
            OriginalVersion = originalVersion;
        }
    }
}
