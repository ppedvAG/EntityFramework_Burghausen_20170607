using Kammmolch.Data.Shared.Interfaces;
using System.Diagnostics;
using System.Collections.Generic;
using Kammmolch.Core.Models;

namespace Kammmolch.Data.Shared.Services
{
    public class OutputChangesLogger : IChangesLogger
    {
        public void LogChanges(IEnumerable<ChangeLog> changes)
        {
            Debug.WriteLine($"  Id | Username        | ChangeTime          | Typename             | PropertyName    | Old  | New");
            foreach (var c in changes)
            {
                Debug.WriteLine($"{c.Id,4} | {c.User,15} | {c.ChangeTime.ToString("yyyy.mm.dd hh:mm:ss")} | {c.TypeName,20} | {c.PropertyName,15} | {c.OldValue,4} | {c.NewValue}");
            }
        }
    }
}
