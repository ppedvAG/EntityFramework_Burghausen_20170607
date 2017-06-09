using HalloCodeFirst.ChangeLoggerTest.Core;

namespace HalloCodeFirst.ChangeLoggerTest.Data
{
    public class IdentityService : IIdentityService
    {
        public string GetUserName()
        {
            return "Jakob";
        }
    }
}
