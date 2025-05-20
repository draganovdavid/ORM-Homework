using CsvHelper.Configuration;
using CsvMovieReader;

public class MovieMap : ClassMap<Movie>
{
    public MovieMap()
    {
        Map(m => m.MovieName).Name("Movie Name");

        Map(m => m.ReleaseYear).Convert(row =>
        {
            var raw = row.Row.GetField("Release Year");
            if (string.IsNullOrWhiteSpace(raw))
                return 0;

            var yearPart = raw.Split('-').First().Trim();
            return int.TryParse(yearPart, out var year) ? year : 0;
        });

        Map(m => m.Duration).Convert(row =>
        {
            var raw = row.Row.GetField("Duration");
            return int.TryParse(raw, out var result) ? result : 0;
        });

        Map(m => m.IMBDRating).Convert(row =>
        {
            var raw = row.Row.GetField("IMDB Rating");
            return double.TryParse(raw, out var rating) ? rating : 0;
        });

        Map(m => m.Metascore).Convert(row =>
        {
            var raw = row.Row.GetField("Metascore");
            return double.TryParse(raw, out var result) ? result : null;
        });

        Map(m => m.Votes).Name("Votes");

        Map(m => m.Genres).Convert(row =>
        {
            var genres = row.Row.GetField("Genre");
            return genres?.Split(',', StringSplitOptions.RemoveEmptyEntries).Select(g => g.Trim()).ToList()
                   ?? new List<string>();
        });

        Map(m => m.Director).Name("Director");
        Map(m => m.Cast).Name("Cast");
        Map(m => m.Gross).Name("Gross");
    }
}
