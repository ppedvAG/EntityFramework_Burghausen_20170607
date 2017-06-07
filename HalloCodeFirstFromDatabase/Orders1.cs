namespace HalloCodeFirstFromDatabase
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Orders1
    {
        [Key]
        public int OrderId { get; set; }

        [StringLength(5)]
        public string CustomerId { get; set; }

        [Column(TypeName = "money")]
        public decimal? Freight { get; set; }
    }
}
