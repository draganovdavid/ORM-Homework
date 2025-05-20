using CsvHelper;
using System.Globalization;
using CsvMovieReader;
using System.Formats.Asn1;

public static class CsvMovieLoader
{
    public static List<Movie> LoadMovies(string filePath)
    {
        using var reader = new StreamReader(filePath);
        using var csv = new CsvReader(reader, CultureInfo.InvariantCulture);

        csv.Context.RegisterClassMap<MovieMap>();
        return csv.GetRecords<Movie>().ToList();
    }
}