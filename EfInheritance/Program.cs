
using EfInheritance.Models;
using System;

namespace EfInheritance
{
    class Program
    {
        static void Main(string[] args)
        {
            TPH();
        }

        private static void TPH()
        {
            using (var context = new InheritanceContext())
            {
                var employee = new Employee { Name = "Sepp", Salery = 3000 };
                var customer = new Customer { Name = "Lisa", Adress = "Musterstraße 1" };

                context.People.Add(employee);
                context.People.Add(customer);

                context.SaveChanges();
            }
        }

        private static void TPT()
        {
            using (var context = new InheritanceContext())
            {
                var lkw = new LKW { Farbe = "Rot", MaxLadung = 13000 };
                var pkw = new PKW { Farbe = "Blau", Sitzplaetze = 5 };

                context.Fahrzeuge.Add(lkw);
                context.Fahrzeuge.Add(pkw);

                context.SaveChanges();
            }
        }

        private static void TPC()
        {
            using (var context = new InheritanceContext())
            {
                var clock = new Clock { Id = 1, Name = "Wanduhr", Time = DateTime.Now };
                var desk = new Desk { Id = 2, Name = "Schreibtisch", Material = "Holz" };

                context.Products.Add(clock);
                context.Products.Add(desk);

                context.SaveChanges();
            }
        }
    }
}
