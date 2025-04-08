namespace ConsoleApp1.Models
{
    using ConsoleApp1.Models.BaseModels;

    public class Airport : BaseModel
    {
        public string Name { get; set; } = null!;

        public int CityId { get; set; }

        public City City { get; set; } = new City();
    }
}
