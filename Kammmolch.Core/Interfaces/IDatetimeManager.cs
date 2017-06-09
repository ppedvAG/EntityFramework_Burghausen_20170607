using System;

namespace Kammmolch.Core.Interfaces
{
    public interface IDatetimeManager
    {
        DateTime Now { get; }
        DateTime UtcNow { get; }
    }
}
