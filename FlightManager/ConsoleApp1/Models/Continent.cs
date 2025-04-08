namespace ConsoleApp1.Models
{
    using ConsoleApp1.Models.BaseModels;

    public class Continent : BaseModel
    {
        public string ContinentName { get; set; } = null!;

        public ICollection<Country> Countries { get; set; } = new List<Country>();
    }
}
