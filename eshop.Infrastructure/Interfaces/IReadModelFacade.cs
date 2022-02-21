using eshop.Infrastructure.Models;
using System;
using System.Collections.Generic;

namespace eshop.Infrastructure.Interfaces
{
    public interface IReadModelFacade
    {
        IEnumerable<QuoteDto> GetQuotes();
        QuoteDetailsDto GetQuoteDetails(Guid id);
    }
}
