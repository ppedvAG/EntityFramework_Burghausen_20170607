using HalloCodeFirst.ChangeLoggerTest.Core;
using System.Data.Entity;
using System.Threading.Tasks;

namespace HalloCodeFirst.ChangeLoggerTest.Data
{
    public class DbChangeLogger : IChangeLogger
    {
        private readonly LogContext _context;
        private readonly IChangesFinder _changesFinder;

        public DbChangeLogger(
            LogContext context,
            IChangesFinder changesfinder)
        {
            _context = context;
            _changesFinder = changesfinder;
        }

        public void LogChanges(DbContext context)
        {
            var changes = _changesFinder.GetChanges(context);

            _context.ChangeLogs.AddRange(changes);
            _context.SaveChanges();
        }

        public async Task LogChangesAsync(DbContext context)
        {
            var changes = _changesFinder.GetChanges(context);

            _context.ChangeLogs.AddRange(changes);
            await _context.SaveChangesAsync();
        }
    }
}
