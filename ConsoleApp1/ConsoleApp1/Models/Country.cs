namespace ConsoleApp1.Models
{
    using ConsoleApp1.Models.BaseModels;

    public class Country : BaseModel
    {
        public string CountryName { get; set; } = null!;

        public int ContinentId { get; set; }

        public Continent Contient { get; set; } = null!;

        public ICollection<City> Cities { get; set; } = new List<City>();
    }
}
