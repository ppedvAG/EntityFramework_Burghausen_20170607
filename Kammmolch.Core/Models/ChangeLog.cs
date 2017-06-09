using System;

namespace Kammmolch.Core.Models
{
    public class ChangeLog : Entity
    {
        public string User { get; set; }
        public string TypeName { get; set; }
        public string PropertyName { get; set; }    // ColumnName
        public object OldValue { get; set; }
        public object NewValue { get; set; }
        public DateTime ChangeTime { get; set; }
    }
}
