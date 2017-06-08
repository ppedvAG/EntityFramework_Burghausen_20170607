using System;
using System.Collections.Generic;

namespace HalloCodeFirst.Models
{
    public class Order : Entity
    {
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }

        //[ForeignKey(nameof(Customer))]
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }

        public ICollection<Article> Articles { get; } = new HashSet<Article>();
    }
}
