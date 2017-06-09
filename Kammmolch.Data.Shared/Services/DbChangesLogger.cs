using Kammmolch.Data.Shared.Interfaces;
using Kammmolch.Data.Logging;
using Kammmolch.Core.Models;
using System.Collections.Generic;

namespace Kammmolch.Data.Shared.Services
{
    public class DbChangesLogger : IChangesLogger
    {
        private readonly LoggingContext _context;

        public DbChangesLogger(
            LoggingContext context)
        {
            _context = context;
        }

        public void LogChanges(IEnumerable<ChangeLog> changes)
        {
            _context.ChangeLogs.AddRange(changes);
            _context.SaveChanges();
        }
    }
}
