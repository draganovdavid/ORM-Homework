using System.IO;

namespace Domain.Entities
{
    public class Movie
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public int ReleaseYear { get; set; }
        public int Duration { get; set; }
        public double IMDBRating { get; set; }
        public double MetaScore { get; set; }
        public int Votes { get; set; }
        public decimal? Gross { get; set; }

        public int GenreId { get; set; }
        public Genre Genre { get; set; } = null!;

        public int DirectorId { get; set; }
        public Director Director { get; set; } = null!;

        public int CastId { get; set; }
        public Cast Cast { get; set; } = null!;
    }
}
