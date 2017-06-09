using System;
using System.Collections.Generic;
using System.Data.Entity;
using HalloCodeFirst.ChangeLoggerTest.Core;
using HalloCodeFirst.ChangeLoggerTest.Core.Models;

namespace HalloCodeFirst.ChangeLoggerTest.Data
{
    public class ChangesFinder : IChangesFinder
    {
        private readonly IIdentityService _identityService;
        private readonly IDateTimeManager _dateTimeManager;

        public ChangesFinder(
            IIdentityService identityService,
            IDateTimeManager dateTimeManager)
        {
            _identityService = identityService;
            _dateTimeManager = dateTimeManager;
        }

        public IEnumerable<ChangeLog> GetChanges(DbContext context)
        {
            var username = _identityService.GetUserName();
            var changeTime = _dateTimeManager.Now;

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
