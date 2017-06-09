
using EfInheritance.Models;
using System.Data.Entity;

namespace EfInheritance
{
    public class InheritanceContext : DbContext
    {
        public InheritanceContext() : base("name=InheritanceConnection")
        { }

        // TPH - Table per Hierachy
        public DbSet<Person> People { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Employee> Employees { get; set; }

        // TPT - Table per Type
        public DbSet<Fahrzeug> Fahrzeuge { get; set; }
        public DbSet<LKW> Lkws { get; set; }
        public DbSet<PKW> Pkws { get; set; }

        // TPC - Table per Concrete Type
        // Basclass must be abstract
        public DbSet<Product> Products { get; set; }
        public DbSet<Clock> Clocks { get; set; }
        public DbSet<Desk> Desks { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // TPH
            modelBuilder.Entity<Person>()
                        .Map<Customer>(m => m.Requires("PersonType").HasValue("C"))
                        .Map<Employee>(m => m.Requires("PersonType").HasValue("E"));

            // TPT
            modelBuilder.Entity<Fahrzeug>().ToTable("Fahrzeuge");
            modelBuilder.Entity<LKW>().ToTable("Lkws");
            modelBuilder.Entity<PKW>().ToTable("Pkws");

            // TPC
            modelBuilder.Entity<Clock>()
                        .Map(m => m.MapInheritedProperties().ToTable("Clocks"));
            modelBuilder.Entity<Desk>()
                        .Map(m => m.MapInheritedProperties().ToTable("Desks"));
        }
    }
}
