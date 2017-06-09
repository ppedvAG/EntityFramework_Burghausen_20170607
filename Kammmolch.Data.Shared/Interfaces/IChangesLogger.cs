using Kammmolch.Core.Models;
using System.Collections.Generic;

namespace Kammmolch.Data.Shared.Interfaces
{
    public interface IChangesLogger
    {
        void LogChanges(IEnumerable<ChangeLog> changes);
    }
}
