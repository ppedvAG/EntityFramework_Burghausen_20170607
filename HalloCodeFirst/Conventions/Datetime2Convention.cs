using System;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace HalloCodeFirst.Conventions
{
    public class Datetime2Convention : Convention
    {
        public Datetime2Convention()
        {
            Properties<DateTime>()
                .Configure(c => c.HasColumnType("datetime2"));
        }
    }
}
