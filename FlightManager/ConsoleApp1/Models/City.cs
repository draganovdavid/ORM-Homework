namespace ConsoleApp1.Models
{
    using ConsoleApp1.Models.BaseModels;

    public class City : BaseModel
    {
        public string CityName { get; set; } = null!;

        public int CountryId { get; set; }

        public Country Country { get; set; } = null!;

        public ICollection<Airport> Airports { get; set; } = new List<Airport>();
    }
}
