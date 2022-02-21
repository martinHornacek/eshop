namespace eshop.Infrastructure.Interfaces
{
    public interface Handles<T>
    {
        void Handle(T message);
    }
}
