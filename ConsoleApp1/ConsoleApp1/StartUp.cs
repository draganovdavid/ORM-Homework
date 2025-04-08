using ConsoleApp1;
using Microsoft.EntityFrameworkCore;

namespace MyApp
{
    public class Program
    {
        static void Main()
        {
            using var context = new FlightDbContext();
            context.Database.Migrate();
            Console.WriteLine("Database created successfully!");
        }
    }
}
