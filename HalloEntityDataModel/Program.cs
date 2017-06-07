using System;
using System.Linq;

namespace HalloEntityDataModel
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var context = new NORTHWNDEntities())
            {
                var employees = context.Employees.ToList();

                foreach (var e in employees)
                {
                    Console.WriteLine($"Id: {e.Id} - {$"{e.FirstName} {e.LastName}", 20} - {e.BirthDate.Value.ToString("dd:mm:yyyy")}");
                }
            }

            Console.ReadLine();
        }
    }
}
