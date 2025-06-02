using Application.Interfaces;
using CsvHelper;
using Domain.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Globalization;
using System.Linq.Expressions;

namespace Infrastructure
{
    public class MovieImporterService : IMovieImporterService
    {
        private readonly MovieDbContext _dbContext;

        public MovieImporterService(MovieDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task ImportMoviesAsync(string csvFilePath)
        {
            using var reader = new StreamReader(csvFilePath);
            using var csv = new CsvReader(reader, CultureInfo.InvariantCulture);
            var records = csv.GetRecords<dynamic>();

            foreach (var record in records)
            {
                string name = record["Movie Name"];
                int year = int.Parse(record["Release Year"]);
                int duration = int.Parse(record["Duration"]);
                double imdb = double.Parse(record["IMDB Rating"]);
                double meta = double.TryParse(record["Metascore"], out double m) ? m : 0;
                int votes = int.Parse(record["Votes"].Replace(",", ""));
                decimal? gross = ParseGross(record["Gross"]);

                string genreName = record["Genre"].Split(',')[0].Trim();
                string directorName = record["Director"];
                string castNames = record["Cast"];

                var genre = await GetOrCreateAsync(_dbContext.Genres, g => g.Name == genreName, () => new Genre { Name = genreName });
                var director = await GetOrCreateAsync(_dbContext.Directors, d => d.Name == directorName, () => new Director { Name = directorName });
                var cast = await GetOrCreateAsync(_dbContext.Casts, c => c.Names == castNames, () => new Cast { Names = castNames });

                var movie = new Movie
                {
                    Name = name,
                    ReleaseYear = year,
                    Duration = duration,
                    IMDBRating = imdb,
                    MetaScore = meta,
                    Votes = votes,
                    Gross = gross,
                    Genre = genre,
                    Director = director,
                    Cast = cast
                };

                _dbContext.Movies.Add(movie);
            }

            await _dbContext.SaveChangesAsync();
        }

        private static async Task<T> GetOrCreateAsync<T>(
            DbSet<T> dbSet,
            Expression<Func<T, bool>> predicate,
            Func<T> createEntity) where T : class
        {
            var entity = await dbSet.FirstOrDefaultAsync(predicate);
            if (entity == null)
            {
                entity = createEntity();
                dbSet.Add(entity);
            }
            return entity;
        }

        private static decimal? ParseGross(string grossStr)
        {
            if (string.IsNullOrWhiteSpace(grossStr) || !grossStr.StartsWith("$")) return null;
            var cleaned = grossStr.Replace("$", "").Replace("M", "");
            return decimal.TryParse(cleaned, NumberStyles.Any, CultureInfo.InvariantCulture, out var val) ? val : null;
        }
    }
}
