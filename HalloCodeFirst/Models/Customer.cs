using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HalloCodeFirst.Models
{
    [Table("Kunden", Schema = "dbo")]
    public class Customer : Entity
    {
        //    [Key]
        //    [Column("KundenId")]
        //    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        //    public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name1 { get; set; }

        //[NotMapped]
        [Required]
        [Column("Adresszusatz", TypeName = "varchar")]
        public string Name2 { get; set; }

        //[DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public string Telephone { get; set; }

        public ICollection<Order> Orders { get; } = new HashSet<Order>();
    }
}
