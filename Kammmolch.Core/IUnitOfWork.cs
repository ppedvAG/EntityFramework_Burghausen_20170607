using Kammmolch.Core.Repositories;
using System;

namespace Kammmolch.Core
{
    public interface IUnitOfWork : IDisposable
    {
        IArticleRepository Articles { get; }
        ICustomerRepository Customers { get; }
        IOrderRepository Orders { get; }

        void Complete();
    }
}
