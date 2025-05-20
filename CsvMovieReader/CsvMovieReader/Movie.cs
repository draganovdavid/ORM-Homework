namespace CsvMovieReader
{
    public class Movie
    {
        public int Id { get; set; }

        public string MovieName { get; set; } = null!;

        public int ReleaseYear { get; set; }

        public int Duration { get; set; }

        public double IMBDRating { get; set; }

        public double? Metascore { get; set; }

        public string Votes { get; set; }

        public List<string> Genres { get; set; } = new List<string>();

        public string Director { get; set; }

        public string Cast { get; set; }

        public string Gross { get; set; }

        public override string ToString()
        {
            return $"{MovieName} ({ReleaseYear}) - Rating: {IMBDRating}, Director: {Director}";
        }
    }
}
