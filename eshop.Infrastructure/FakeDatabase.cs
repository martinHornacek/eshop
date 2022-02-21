using eshop.Infrastructure.Models;
using System;
using System.Collections.Generic;

namespace eshop.Infrastructure
{
    internal class FakeDatabase
    {
        public static Dictionary<Guid, QuoteDetailsDto> quotedetails = new Dictionary<Guid, QuoteDetailsDto>();
        public static List<QuoteDto> quotes = new List<QuoteDto>();
    }
}
