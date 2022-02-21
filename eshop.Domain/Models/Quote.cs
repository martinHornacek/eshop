using eshop.Domain.Core;
using eshop.Domain.Events;
using System;

namespace eshop.Domain.Models
{
    public class Quote : AggregateRoot
    {
        private bool _draft;
        private Guid _id;

        private void Apply(QuoteCreated e)
        {
            _id = e.Id;
            _draft = true;
        }

        private void Apply(QuoteActivated e)
        {
            _draft = false;
        }

        public void RenameQuote(string newName)
        {
            if (string.IsNullOrEmpty(newName)) throw new ArgumentException(nameof(newName));
            ApplyChange(new QuoteRenamed(_id, newName));
        }

        public void RemoveQuoteProducts(int count)
        {
            if (count <= 0) throw new InvalidOperationException("Cannot remove negative count from Quote.");
            ApplyChange(new QuoteProductsRemovedFromQuote(_id, count));
        }


        public void AddQuoteProducts(int count)
        {
            if (count <= 0) throw new InvalidOperationException("Must have a count greater than 0 to add to Quote.");
            ApplyChange(new QuoteProductsAddedToQuote(_id, count));
        }

        public void ActivateQuote()
        {
            if (_draft != true) throw new InvalidOperationException("Can activate only draft Quote.");
            ApplyChange(new QuoteActivated(_id));
        }

        public override Guid Id
        {
            get { return _id; }
        }

        public Quote()
        {
        }

        public Quote(Guid id, string name)
        {
            ApplyChange(new QuoteCreated(id, name));
        }
    }
}
