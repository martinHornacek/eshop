using System;

namespace eshop.Infrastructure.Models
{
    public class QuoteDto
    {
        public Guid Id;
        public string Name;

        public QuoteDto(Guid id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
