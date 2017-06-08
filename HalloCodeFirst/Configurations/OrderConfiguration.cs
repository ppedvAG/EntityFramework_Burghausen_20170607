using HalloCodeFirst.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace HalloCodeFirst.Configurations
{
    internal class OrderConfiguration : EntityTypeConfiguration<Order>
    {
        public OrderConfiguration()
        {
            ToTable("Aufträge", "dbo");
            HasKey(o => o.Id);
            //HasKey(o => new { o.Id, o.Id2 });

            Property(o => o.Description)
                .IsRequired()
                .IsMaxLength()
                .IsUnicode(true)
                .HasColumnName("Auftragstext")
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            HasRequired(o => o.Customer)
                .WithMany(c => c.Orders)
                .HasForeignKey(o => o.CustomerId);
        }
    }
}