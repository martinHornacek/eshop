using eshop.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;

namespace eshop.Infrastructure.Models
{
    public class ReadModelFacade : IReadModelFacade
    {
        public IEnumerable<QuoteDto> GetQuotes()
        {
            return FakeDatabase.quotes;
        }

        public QuoteDetailsDto GetQuoteDetails(Guid id)
        {
            return FakeDatabase.quotedetails[id];
        }
    }
}
