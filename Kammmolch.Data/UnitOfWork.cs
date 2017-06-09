using Kammmolch.Core;
using Kammmolch.Core.Repositories;
using Kammmolch.Data.Shared.Interfaces;
using Kammmolch.Data.Repositories;

namespace Kammmolch.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ErpContext _context;
        private readonly IChangesLogger _changesLogger;
        private readonly IChangesFinder _changesFinder;

        public IArticleRepository Articles { get; }
        public ICustomerRepository Customers { get; }
        public IOrderRepository Orders { get; }

        public UnitOfWork(
            ErpContext context,
            IChangesFinder changesFinder,
            IChangesLogger changesLogger)
        {
            _context = context;
            Articles = new ArticleRepository(context);
            Customers = new CustomerRepository(context);
            Orders = new OrderRepository(context);

            _changesFinder = changesFinder;
            _changesLogger = changesLogger;
        }

        public void Complete()
        {
            if (!_context.ChangeTracker.HasChanges())
                return;

            var changes = _changesFinder.GetChanges(_context);
            _context.SaveChanges();
            _changesLogger.LogChanges(changes);
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
