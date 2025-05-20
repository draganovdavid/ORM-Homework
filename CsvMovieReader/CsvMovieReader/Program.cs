namespace CsvMovieReader;
class Program
{
    static void Main()
    {
        var path = "C:\\Users\\david\\source\\repos\\CsvMovieReader\\CsvMovieReader\\imdb_top_2000_movies.csv"; // Променяш спрямо местоположението на файла
        var movies = CsvMovieLoader.LoadMovies(path);

        foreach (var movie in movies)
        {
            Console.WriteLine(movie); // ToString() ще се използва
        }

        // В реално приложение тук ще направим Save в базата:
        using var db = new MovieDbContext();
        db.Database.EnsureCreated();
        db.Movies.AddRange(movies);
        db.SaveChanges();

        Console.WriteLine("The data is imported successfully!");
    }
}
