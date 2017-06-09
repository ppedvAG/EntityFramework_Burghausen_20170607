using Kammmolch.Core.Models;
using System.Data.Entity.ModelConfiguration;

namespace Kammmolch.Data.Configurations
{
    internal class CustomerConfiguration : EntityTypeConfiguration<Customer>
    {
        public CustomerConfiguration()
        {
            ToTable("Kunden", "dbo");

            Property(c => c.Id).HasColumnName("KundenId");

            Property(c => c.Name1)
                .IsRequired()
                .HasMaxLength(100);

            Property(c => c.Name2)
                .IsRequired()
                .HasColumnName("Adresszusatz")
                .HasColumnType("varchar");
        }
    }
}
