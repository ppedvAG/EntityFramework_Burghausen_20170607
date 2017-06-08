using HalloCodeFirst.Configurations;
using HalloCodeFirst.Conventions;
using HalloCodeFirst.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace HalloCodeFirst
{
    public class ErpContext : DbContext
    {
        public ErpContext()
            : base("name=ErpConnectionString")
        { }

        public DbSet<Article> Articles { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>().Property(c => c.Id).HasColumnName("KundenId");

            modelBuilder.Configurations.Add(new ArticleConfiguration());
            modelBuilder.Configurations.Add(new OrderConfiguration());

            modelBuilder.Conventions.Add<Datetime2Convention>();
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder.Properties<string>()
                .Configure(c => c.HasMaxLength(200).IsRequired());
            modelBuilder.Properties<string>()
                .Where(p => p.Name.ToLower().Contains("description"))
                .Configure(c => c.IsMaxLength().IsOptional());

            modelBuilder.Properties<byte[]>()
                .Where(p => p.Name.Equals("Timestamp"))
                .Configure(c => c.IsRowVersion());
        }
    }
}
