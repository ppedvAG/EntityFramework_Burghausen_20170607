using HalloCodeFirst.Models;
using System.Data.Entity.ModelConfiguration;

namespace HalloCodeFirst.Configurations
{
    public class ArticleConfiguration : EntityTypeConfiguration<Article>
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
