using Kammmolch.Core.Models;
using System.Collections.Generic;
using System.Data.Entity;

namespace Kammmolch.Data.Shared.Interfaces
{
    public interface IChangesFinder
    {
        IEnumerable<ChangeLog> GetChanges(DbContext context);
    }
}
