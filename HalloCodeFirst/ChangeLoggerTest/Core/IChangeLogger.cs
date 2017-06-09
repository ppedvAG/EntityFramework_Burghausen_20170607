using System.Data.Entity;
using System.Threading.Tasks;

namespace HalloCodeFirst.ChangeLoggerTest.Core
{
    public interface IChangeLogger
    {
        void LogChanges(DbContext context);
        Task LogChangesAsync(DbContext context);
    }
}
