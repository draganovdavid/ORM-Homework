using Microsoft.EntityFrameworkCore;

namespace CsvMovieReader
{
    public class MovieDbContext : DbContext
    {
        public DbSet<Movie> Movies { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DAVID\\SQLEXPRESS;Database=MoviesDb;Trusted_Connection=True;TrustServerCertificate=True");

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Movie>()
                .Property(m => m.Genres)
                .HasConversion(
                    g => string.Join(',', g),
                    s => s.Split(',', StringSplitOptions.RemoveEmptyEntries).ToList());
        }
    }
}
