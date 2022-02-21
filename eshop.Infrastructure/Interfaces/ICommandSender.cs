using eshop.Domain.Core;

namespace eshop.Infrastructure.Interfaces
{
    public interface ICommandSender
    {
        void Send<T>(T command) where T : Command;
    }
}
