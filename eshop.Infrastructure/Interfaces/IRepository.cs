using eshop.Domain.Core;
using System;

namespace eshop.Infrastructure.Interfaces
{
    public interface IRepository<T> where T : AggregateRoot, new()
    {
        void Save(AggregateRoot aggregate, int expectedVersion);
        T GetById(Guid id);
    }
}
