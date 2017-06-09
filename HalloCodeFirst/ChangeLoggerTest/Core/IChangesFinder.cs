using HalloCodeFirst.ChangeLoggerTest.Core.Models;
using System.Collections.Generic;
using System.Data.Entity;

namespace HalloCodeFirst.ChangeLoggerTest.Core
{
    public interface IChangesFinder
    {
        IEnumerable<ChangeLog> GetChanges(DbContext context);
    }
}
