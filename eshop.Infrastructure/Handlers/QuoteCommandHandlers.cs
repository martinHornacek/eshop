using eshop.Domain.Commands;
using eshop.Domain.Models;
using eshop.Infrastructure.Interfaces;

namespace eshop.Infrastructure.Handlers
{
    public class QuoteCommandHandlers
    {
        private readonly IRepository<Quote> _repository;

        public QuoteCommandHandlers(IRepository<Quote> repository)
        {
            _repository = repository;
        }

        public void Handle(CreateQuote message)
        {
            var item = new Quote(message.QuoteId, message.Name);
            _repository.Save(item, -1);
        }

        public void Handle(ActivateQuote message)
        {
            var item = _repository.GetById(message.QuoteId);
            item.ActivateQuote();
            _repository.Save(item, message.OriginalVersion);
        }

        public void Handle(RemoveQuoteProductsFromQuote message)
        {
            var item = _repository.GetById(message.QuoteId);
            item.RemoveQuoteProducts(message.Count);
            _repository.Save(item, message.OriginalVersion);
        }

        public void Handle(AddQuoteProductsToQuote message)
        {
            var item = _repository.GetById(message.QuoteId);
            item.AddQuoteProducts(message.Count);
            _repository.Save(item, message.OriginalVersion);
        }

        public void Handle(RenameQuote message)
        {
            var item = _repository.GetById(message.QuoteId);
            item.RenameQuote(message.NewName);
            _repository.Save(item, message.OriginalVersion);
        }
    }
}
