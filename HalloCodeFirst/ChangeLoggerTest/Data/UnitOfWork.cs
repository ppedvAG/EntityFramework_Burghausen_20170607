using HalloCodeFirst.ChangeLoggerTest.Core;

namespace HalloCodeFirst.ChangeLoggerTest.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ErpContext _context;
        private readonly IChangeLogger _changeLogger;

        public UnitOfWork(ErpContext context, IChangeLogger changeLogger)
        {
            _context = context;
            _changeLogger = changeLogger;
        }

        public void Complete()
        {
            if (!_context.ChangeTracker.HasChanges())
                return;

            _changeLogger.LogChanges(_context);
            _context.SaveChanges();
        }
    }
}
