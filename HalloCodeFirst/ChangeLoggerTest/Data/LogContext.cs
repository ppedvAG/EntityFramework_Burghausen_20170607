using HalloCodeFirst.ChangeLoggerTest.Core.Models;
using System.Data.Entity;

namespace HalloCodeFirst.ChangeLoggerTest.Data
{
    public class LogContext : DbContext
    {
        public LogContext(string nameOrConnectionstring)
            : base(nameOrConnectionstring)
        { }

        public DbSet<ChangeLog> ChangeLogs { get; set; }
    }
}