using Kammmolch.Core.Models;
using System.Data.Entity.ModelConfiguration;

namespace Kammmolch.Data.Configurations
{
    internal class ArticleConfiguration : EntityTypeConfiguration<Article>
    {
        public ArticleConfiguration()
        {
            ToTable("Artikel");
            HasKey(a => a.Id);

            Property(a => a.Name)
                .IsRequired()
                .HasMaxLength(150);

            HasMany(a => a.Orders)
                .WithMany(o => o.Articles)
                .Map(m =>
                {
                    m.ToTable("ArtikelAuftraege");
                    m.MapLeftKey("Artikelnummer");
                    m.MapRightKey("Auftragsnummer");
                });
        }
    }
}
