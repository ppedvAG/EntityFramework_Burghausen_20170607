namespace HalloCodeFirstFromDatabase
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class KDUs2
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(5)]
        public string CustomerId { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(40)]
        public string CompanyName { get; set; }

        [StringLength(15)]
        public string Country { get; set; }

        [StringLength(15)]
        public string Stadt { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(4)]
        public string TextSpalte { get; set; }
    }
}
