using System;
using System.Collections.Generic;
using System.Linq;

namespace DelegatesInPraxis
{
    public delegate bool MyDelegate(Employee e);
    // Action -> void
    // Predicate -> bool
    // Func

    class Program
    {
        static void Main(string[] args)
        {
            var employees = GetData();

            //MyDelegate del = new MyDelegate(Bedingung);
            //Func<Employee, bool> del = new Func<Employee, bool>(Bedingung);
            //var del = new Func<Employee, bool>(Bedingung);
            //Func<Employee, bool> del = Bedingung;
            //var query = Abfrage(employees, del);

            //var query = Abfrage(employees, Bedingung);

            //var query = Abfrage(employees, delegate (Employee e)
            //{
            //    return e.Experience < 5;
            //});

            //var query = Abfrage(employees, (Employee e) =>
            //{
            //    return e.Experience < 5;
            //});

            //var query = Abfrage(employees, (e) =>
            //{
            //    return e.Experience < 5;
            //});

            //var query = Abfrage(employees, (e) => e.Experience < 5 || e.Experience > 10);
            var query = MyExtentions.Abfrage(employees, e => e.Experience < 5);
            var query2 = employees.Abfrage(e => e.Experience > 5);
            var linq = employees.Where(Bedingung);
            var linq2 = employees.Where(e => e.Experience > 5);

            foreach (var e in query)
            {
                Console.WriteLine($"Id: {e.Id} - {e.Name,10} - {e.Experience}");
            }
            Console.ReadKey();
        }

        private static bool Bedingung(Employee employee)
        {
            return employee.Name.Contains("a");
        }

        private static IEnumerable<Employee> GetData()
        {
            return new List<Employee>
            {
                new Employee { Id = 1, Name = "Sepp", Experience = 6 },
                new Employee { Id = 2, Name = "Maria", Experience = 5 },
                new Employee { Id = 3, Name = "Thomas", Experience = 10 },
                new Employee { Id = 4, Name = "Stanislaus", Experience = 14 },
                new Employee { Id = 5, Name = "Lisa", Experience = 6 },
                new Employee { Id = 6, Name = "Anton", Experience = 1 },
                new Employee { Id = 7, Name = "Alexandra", Experience = 3 },
                new Employee { Id = 8, Name = "Mario", Experience = 18 },
                new Employee { Id = 9, Name = "Paula", Experience = 3 },
            };
        }
    }

    public static class MyExtentions
    {
        public static IEnumerable<T> Abfrage<T>(
           this IEnumerable<T> employees,
           Func<T, bool> predicate)
        {
            foreach (var e in employees)
                if (predicate(e))
                    yield return e;
        }
    }
}
