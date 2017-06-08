using System.Collections.Generic;

namespace HalloCodeFirst.Models
{
    public class Article : Entity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }

        public ICollection<Order> Orders { get; } = new HashSet<Order>();
    }
}
