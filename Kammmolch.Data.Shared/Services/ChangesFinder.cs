using System.Collections.Generic;
using System.Data.Entity;
using Kammmolch.Data.Shared.Interfaces;
using Kammmolch.Core.Interfaces;
using Kammmolch.Core.Models;

namespace Kammmolch.Data.Shared.Services
{
    public class ChangesFinder : IChangesFinder
    {
        private readonly IIdentityManger _identityManager;
        private readonly IDatetimeManager _datetimeManager;

        public ChangesFinder(
            IIdentityManger identityManager,
            IDatetimeManager datetimeManager)
        {
            _identityManager = identityManager;
            _datetimeManager = datetimeManager;
        }

        public IEnumerable<ChangeLog> GetChanges(DbContext context)
        {
            var username = _identityManager.GetUsername();
            var changeTime = _datetimeManager.UtcNow;

            var changes = new List<ChangeLog>();
            foreach (var entry in context.ChangeTracker.Entries())
            {
                var propertyNames = entry.OriginalValues.PropertyNames;

                foreach (var propertyName in propertyNames)
                {
                    var property = entry.Property(propertyName);
                    if (property.IsModified)
                        changes.Add(new ChangeLog
                        {
                            User = username,
                            ChangeTime = changeTime,
                            TypeName = entry.Entity.GetType().Name,
                            PropertyName = propertyName,
                            OldValue = property.OriginalValue,
                            NewValue = property.CurrentValue
                        });
                }
            }

            return changes;
        }
    }
}
