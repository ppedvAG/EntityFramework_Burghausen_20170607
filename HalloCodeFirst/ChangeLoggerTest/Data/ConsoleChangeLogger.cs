using System;
using System.Data.Entity;
using System.Threading.Tasks;
using HalloCodeFirst.ChangeLoggerTest.Core;

namespace HalloCodeFirst.ChangeLoggerTest.Data
{
    public class ConsoleChangeLogger : IChangeLogger
    {
        private readonly IChangesFinder _changesFinder;

        public ConsoleChangeLogger(
            IChangesFinder changesFinder)
        {
            _changesFinder = changesFinder;
        }

        public void LogChanges(DbContext context)
        {
            var changes = _changesFinder.GetChanges(context);

            Console.WriteLine($"  Id | Username        | ChangeTime          | Typename             | PropertyName    | Old  | New");
            foreach (var c in changes)
            {
                Console.WriteLine($"{c.Id,4} | {c.User,15} | {c.ChangeTime.ToString("yyyy.mm.dd hh:mm:ss")} | {c.TypeName,20} | {c.PropertyName,15} | {c.OldValue,4} | {c.NewValue}");
            }
        }

        public Task LogChangesAsync(DbContext context)
        {
            throw new NotImplementedException();
        }
    }
}
