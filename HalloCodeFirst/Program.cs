using HalloCodeFirst.ChangeLoggerTest.Data;
using HalloCodeFirst.Models;
using System;
using System.Data.Entity;
using System.Linq;
using Tynamix.ObjectFiller;

namespace HalloCodeFirst
{
    partial class Program
    {
        static void Main(string[] args)
        {
            EagerLoading();

            Console.ReadKey();
        }

        public static void TestChangeLoggerTest()
        {
            using (var context = new ErpContext())
            {
                var identityService = new IdentityService();
                var dateTimeManager = new DateTimeManager();
                var changesFinder = new ChangesFinder(identityService, dateTimeManager);
                var changeLogger = new ConsoleChangeLogger(changesFinder);

                var unitOfWork = new UnitOfWork(context, changeLogger);

                var customer = context.Customers.First();

                customer.Name1 = "Max";
                customer.Name2 = "Lustig";

                unitOfWork.Complete();
            }
        }

        public static void Linq()
        {
            // Language integrated Query

            using (var context = new ErpContext())
            {

                #region Restriction

                // Linq
                //var query = from c in context.Customers
                //            where c.Orders.Count > 20
                //            select c;

                // Fluent API
                //var query = context.Customers.Where(c => c.Orders.Count > 20);

                //foreach (var c in query)
                //{
                //    Console.WriteLine(c.Name1);
                //}

                #endregion
                #region Ordering

                // Linq
                //var query = from o in context.Orders
                //            orderby o.Price ascending, o.Description descending
                //            select o;

                //// Fluent API
                //var query = context.Orders.OrderByDescending(o => o.Price).ThenBy(o => o.Description);

                //foreach (var o in query)
                //{
                //    Console.WriteLine(o.Price);
                //}

                #endregion
                #region Projection

                //var query = from o in context.Orders
                //            select new { Kosten = o.Price, Datum = o.Date };

                //var query = context.Orders.Select(o => new { Kosten = o.Price, Datum = o.Date });

                //foreach (var o in query)
                //{
                //    Console.WriteLine(o.Kosten);
                //}

                #endregion
                #region Grouping

                //var query = from o in context.Orders
                //            group o by o.Date.Year into g
                //            select new { Year = g.Key, Orders = g };

                //var query = context.Orders.GroupBy(o => o.Date.Year)
                //                          .Select(g => new { Year = g.Key, Orders = g });

                //foreach (var item in query)
                //{
                //    Console.WriteLine(item.Year);

                //    foreach (var o in item.Orders)
                //    {
                //        Console.WriteLine($"\t{o.Price, 10}");
                //    }
                //}

                #endregion
                #region Inner Join

                //var query = from o in context.Orders
                //            join c in context.Customers on o.CustomerId equals c.Id
                //            select new { Firstname = c.Name1, o.Price };

                //var query = context.Orders.Join(
                //    inner: context.Customers,
                //    outerKeySelector: o => o.CustomerId,
                //    innerKeySelector: c => c.Id,
                //    resultSelector: (o, c) => new { Firstname = c.Name1, o.Price });

                //foreach (var item in query)
                //{
                //    Console.WriteLine($"{item.Firstname} - {item.Price}");
                //}

                #endregion
                #region Group Join

                //var query = from c in context.Customers
                //            join o in context.Orders on c.Id equals o.CustomerId into g
                //            select new { Firstname = c.Name1, Orders = g.Count() };

                //var query = context.Customers.GroupJoin(
                //    inner: context.Orders,
                //    outerKeySelector: c => c.Id,
                //    innerKeySelector: o => o.CustomerId,
                //    resultSelector: (c, g) => new { Firstname = c.Name1, Orders = g.Count() });

                //foreach (var item in query)
                //{
                //    Console.WriteLine($"{item.Firstname} {item.Orders}");
                //}
                #endregion
                #region Cross Join

                //var query = (from c in context.Customers
                //            from o in context.Orders
                //            select new { Firstname = c.Name1, Price = o.Price }).ToList();

                //var query1 = context.Customers.SelectMany(_ => context.Orders,
                //    (c, o) => new { Firstname = c.Name1, Price = o.Price }).ToList();

                //foreach (var item in query)
                //{
                //    Console.WriteLine($"{item.Firstname} - {item.Price}");
                //}

                #endregion
                #region Element Operators

                //var customer = context.Customers.First();
                //var customer = context.Customers.FirstOrDefault();
                //var customer = context.Customers.First(c => c.Name1.StartsWith("A"));
                //var customer = context.Customers.FirstOrDefault(c => c.Name1.StartsWith("A"));


                //var customer = context.Customers.Single();
                //var customer = context.Customers.SingleOrDefault();
                //var customer = context.Customers.Single(c => c.Name1.StartsWith("A"));
                //var customer = context.Customers.SingleOrDefault(c => c.Name1.StartsWith("A"));

                // Wird von SQL Server nicht unterstützt!
                //var customer = context.Customers.Last();
                //var customer = context.Customers.LastOrDefault();
                //var customer = context.Customers.Last(c => c.Name1.StartsWith("A"));
                //var customer = context.Customers.LastOrDefault(c => c.Name1.StartsWith("A"));

                #endregion
                #region Quantifying

                //var allOrdersInYear2000 = context.Orders.All(o => o.Date.Year == 2000);
                //var anyOrdersInYear2000 = context.Orders.Any(o => o.Date.Year == 2000);

                #endregion
                #region Aggregating

                //var count = context.Customers.Count();
                //var count = context.Customers.Count(c => c.Name1.StartsWith("A"));

                var max = context.Orders.Max(o => o.Price);
                var min = context.Orders.Min(o => o.Price);
                var avg = context.Orders.Average(o => o.Price);
                var sum = context.Orders.Sum(o => o.Price);

                #endregion
            }
        }

        public static void AsNoTracking()
        {
            Customer c;
            using (var context = new ErpContext())
            {
                var customers = context.Customers.AsNoTracking().Take(10).ToList();

                foreach (var entry in context.ChangeTracker.Entries())
                    Console.WriteLine(entry.State);

                Console.WriteLine("10 geladen");
                c = customers.First();

                var orders = context.Orders.Where(o => o.CustomerId == c.Id).ToList();

                //c.Name1 = "";

                //context.Customers.Attach(c);

                //context.Entry(c).Property(cus => cus.Name1).IsModified = true;

                //Console.WriteLine("Einer attached.");
                //foreach (var entry in context.ChangeTracker.Entries())
                //    Console.WriteLine(entry.State);
            }

            using (var context = new ErpContext())
            {
                context.Customers.Attach(c);

                Console.WriteLine("Am neuen Context.");
                foreach (var entry in context.ChangeTracker.Entries())
                    Console.WriteLine(entry.State);
            }
        }

        public static void ChangeTracker()
        {
            using (var context = new ErpContext())
            {
                context.Customers.Take(10).ToList();
                var customer = context.Customers.First();

                Console.WriteLine($"Zuvor: {customer.Name1} {customer.Name2}");
                Console.WriteLine($"HasChanges? {context.ChangeTracker.HasChanges()}");

                customer.Name1 = "Luis";

                Console.WriteLine($"Danach: {customer.Name1} {customer.Name2}");
                Console.WriteLine($"HasChanges? {context.ChangeTracker.HasChanges()}");

                Console.WriteLine();
                Console.WriteLine("Elemente im Changetracker:");
                foreach (var entry in context.ChangeTracker.Entries<Customer>())
                {
                    Console.WriteLine(entry.State);
                }

                //context.SaveChanges();
            }
        }

        public static void Test()
        {
            using (var context = new ErpContext())
            {
                var customer = context.Customers.Take(50);

                foreach (var c in customer)
                {
                    Console.WriteLine($"{c.Name1} {c.Name2}");
                }
            }
        }

        public static void LazyLoading()        // Stand Juni 2017 - Nicht in EF Core
        {
            using (var context = new ErpContext())
            {
                // In den Entity Klassen müssen alle Navigationsproperties virtual sein
                context.Configuration.LazyLoadingEnabled = true;        // Standard -> true

                var customers = context.Customers.Take(150).ToList();

                foreach (var c in customers)
                {
                    Console.WriteLine($"{c.Name1} {c.Name2}");

                    foreach (var o in c.Orders)     // N + 1 Problem
                    {
                        Console.WriteLine($"\t{o.Date.ToString("dd.mm.yyyy")}");
                    }
                }
            }
        }
        public static void EagerLoading()
        {
            using (var context = new ErpContext())
            {

                context.Database.Log = Console.WriteLine;

                var customers = context.Customers.Include(c => c.Orders)
                                                 .Where(c => c.Orders.All(o => o.Price < 500))
                                                 .Take(150).ToList();

                foreach (var c in customers)
                {
                    Console.WriteLine($"{c.Name1} {c.Name2}");

                    foreach (var o in c.Orders)
                    {
                        Console.WriteLine($"\t{o.Date.ToString("dd.mm.yyyy")}");
                    }
                }
            }
        }
        public static void PreLoading()
        {
            using (var context = new ErpContext())
            {
                context.Customers.First();

                var orders = context.Orders.Take(20);
                foreach (var o in orders)
                {
                    Console.WriteLine($"{o.Date.ToString("dd.mm.yyy")} - {o.Customer.Name1}");
                }
            }
        }

        public static void IQueryableExample()
        {
            using (var context = new ErpContext())
            {
                var result = context.Orders.OrderBy(o => o.Date).Where(o => o.Price > 500);

                var x = result.Where(o => o.Price < 2000).ToList();
            }
        }

        private async static void CreateSampleData()
        {
            var customerFiller = new Filler<Customer>();
            customerFiller.Setup()
                .OnProperty(c => c.Id).IgnoreIt()
                .OnProperty(c => c.Orders).IgnoreIt()
                .OnProperty(c => c.Name1).Use(new RealNames(NameStyle.FirstName))
                .OnProperty(c => c.Name2).Use(new RealNames(NameStyle.LastName))
                .OnProperty(c => c.Telephone).Use(new PatternGenerator("0049 {C:1000}-{C:100} {C:10} {C:1000}"));

            var orderFiller = new Filler<Order>();
            orderFiller.Setup()
                .OnProperty(o => o.Id).IgnoreIt()
                .OnProperty(o => o.Customer).IgnoreIt()
                .OnProperty(o => o.CustomerId).IgnoreIt()
                .OnProperty(o => o.Articles).IgnoreIt()
                .OnProperty(o => o.Price).IgnoreIt()
                .OnProperty(o => o.Description).Use(new Lipsum(LipsumFlavor.InDerFremde))
                .OnProperty(o => o.Date).Use(new DateTimeRange(DateTime.Now.AddYears(-20)));

            var articleFiller = new Filler<Article>();
            articleFiller.Setup()
                .OnProperty(a => a.Id).IgnoreIt()
                .OnProperty(a => a.Orders).IgnoreIt()
                .OnProperty(a => a.Description).Use(new Lipsum(LipsumFlavor.InDerFremde))
                .OnProperty(a => a.Price).Use(new DoubleRange(5, 5000))
                .OnProperty(a => a.Name).Use(new RandomListItem<string>(
                    "Apfel", "Birne", "Dampfschiff", "Akkuschrauber", "Kirschbaum", "iPhone", "Leder Geldbörse",
                    "Fineliner", "Notizblock", "Skateboard", "Pkw", "Besteck", "Öltanker", "LED", "Fernseher",
                    "Plattenspieler", "CD", "LP", "Flipchart", "Ziegelstein"));

            var random = new Random();
            var customers = customerFiller.Create(500);

            foreach (var c in customers)
            {
                var actualOrders = orderFiller.Create(random.Next(1, 100));
                foreach (var o in actualOrders)
                    c.Orders.Add(o);
            }

            var articles = articleFiller.Create(1000).ToList();

            var orders = customers.SelectMany(c => c.Orders);
            foreach (var o in orders)
            {
                for (int i = 0; i < random.Next(1, 50); i++)
                {
                    o.Articles.Add(articles[random.Next(0, articles.Count - 1)]);
                }

                o.Price = o.Articles.Sum(a => a.Price);
            }

            using (var context = new ErpContext())
            {
                context.Customers.AddRange(customers);
                await context.SaveChangesAsync();
                Console.WriteLine("Fertig");
            }
        }
    }
}