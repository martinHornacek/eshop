using eshop.Domain.Events;
using eshop.Infrastructure.Interfaces;
using System;

namespace eshop.Infrastructure.Models
{
    public class QuoteView : Handles<QuoteCreated>, Handles<QuoteRenamed>, Handles<QuoteActivated>
    {
        public void Handle(QuoteCreated message)
        {
            FakeDatabase.quotes.Add(new QuoteDto(message.Id, message.Name));
        }

        public void Handle(QuoteRenamed message)
        {
            var item = FakeDatabase.quotes.Find(x => x.Id == message.Id);
            item.Name = message.NewName;
        }

        public void Handle(QuoteActivated message)
        {
            FakeDatabase.quotes.RemoveAll(x => x.Id == message.Id);
        }
    }

    public class QuoteProductsView : Handles<QuoteCreated>, Handles<QuoteActivated>, Handles<QuoteRenamed>, Handles<QuoteProductsRemovedFromQuote>, Handles<QuoteProductsAddedToQuote>
    {
        public void Handle(QuoteCreated message)
        {
            FakeDatabase.quotedetails.Add(message.Id, new QuoteDetailsDto(message.Id, message.Name, 0, 0));
        }

        public void Handle(QuoteRenamed message)
        {
            QuoteDetailsDto d = GetQuoteDetails(message.Id);
            d.Name = message.NewName;
            d.Version = message.Version;
        }

        private QuoteDetailsDto GetQuoteDetails(Guid id)
        {
            QuoteDetailsDto d;

            if (!FakeDatabase.quotedetails.TryGetValue(id, out d))
            {
                throw new InvalidOperationException("Did not find the original quote.. This should not happen.");
            }

            return d;
        }

        public void Handle(QuoteProductsRemovedFromQuote message)
        {
            QuoteDetailsDto d = GetQuoteDetails(message.Id);
            d.CurrentCount -= message.Count;
            d.Version = message.Version;
        }

        public void Handle(QuoteProductsAddedToQuote message)
        {
            QuoteDetailsDto d = GetQuoteDetails(message.Id);
            d.CurrentCount += message.Count;
            d.Version = message.Version;
        }

        public void Handle(QuoteActivated message)
        {
            FakeDatabase.quotedetails.Remove(message.Id);
        }
    }
}
