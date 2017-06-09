using System;
using HalloCodeFirst.ChangeLoggerTest.Core;

namespace HalloCodeFirst.ChangeLoggerTest.Data
{
    public class DateTimeManager : IDateTimeManager
    {
        public DateTime Now => DateTime.Now;

        public DateTime UtcNow => DateTime.UtcNow;
    }
}
