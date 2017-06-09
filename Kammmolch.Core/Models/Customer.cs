using System.Collections.Generic;

namespace Kammmolch.Core.Models
{
    public class Customer : Entity
    {
        public string Name1 { get; set; }
        public string Name2 { get; set; }
        public string Telephone { get; set; }

        public ICollection<Order> Orders { get; } = new HashSet<Order>();
    }
}
