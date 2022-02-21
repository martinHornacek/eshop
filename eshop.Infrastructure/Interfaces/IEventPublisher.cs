using eshop.Domain.Core;

namespace eshop.Infrastructure.Interfaces
{
    public interface IEventPublisher
    {
        void Publish<T>(T @event) where T : Event;
    }
}
