using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Infrastructure.Data
{
    public class MovieDbContextFactory : IDesignTimeDbContextFactory<MovieDbContext>
    {
        public MovieDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<MovieDbContext>();

            optionsBuilder.UseSqlServer("Server=DAVID;Database=MovieImporter;Trusted_Connection=True;TrustServerCertificate=True;\r\n");

            return new MovieDbContext(optionsBuilder.Options);
        }
    }
}
