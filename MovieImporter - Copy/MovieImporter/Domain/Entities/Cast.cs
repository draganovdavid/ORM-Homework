namespace Domain.Entities
{
    public class Cast
    {
        public int Id { get; set; }
        public string Names { get; set; } = null!;
        public ICollection<Movie> Movies { get; set; } = null!;
    }
}
