using Application.Interfaces;
using Infrastructure;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace MovieImporter
{
    public class Program
    {
        static async Task Main(string[] args)
        {
            var services = new ServiceCollection();

            services.AddDbContext<MovieDbContext>(options =>
            {
                options
                .UseSqlServer("Server=DAVID;Database=MovieImporter;Trusted_Connection=True;TrustServerCertificate=True;\r\n");
            });

            services.AddScoped<IMovieImporterService, MovieImporterService>();

            var serviceProvider = services.BuildServiceProvider();
            var importer = serviceProvider.GetRequiredService<IMovieImporterService>();

            await importer.ImportMoviesAsync("C:\\Users\\PC\\Desktop\\MovieImporter\\MovieImporter\\MovieImporter\\imdb_top_2000_movies.csv");

            Console.WriteLine("Импортирането е завършено.");
        }
    }
}