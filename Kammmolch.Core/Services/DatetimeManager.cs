using System;
using Kammmolch.Core.Interfaces;

namespace Kammmolch.Core.Services
{
    public class DatetimeManager : IDatetimeManager
    {
        public DateTime Now => DateTime.Now;

        public DateTime UtcNow => DateTime.UtcNow;
    }
}
