using Kammmolch.Core.Models;
using System.Data.Entity;

namespace Kammmolch.Data.Logging
{
    public class LoggingContext : DbContext
    {
        public DbSet<ChangeLog> ChangeLogs { get; set; }
    }
}
