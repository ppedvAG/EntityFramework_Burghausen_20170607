using System;

namespace HalloCodeFirst.ChangeLoggerTest.Core
{
    public interface IDateTimeManager
    {
        DateTime Now { get; }
        DateTime UtcNow { get; }
    }
}
