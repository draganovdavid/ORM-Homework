namespace ConsoleApp1.Models
{
    using ConsoleApp1.Models.BaseModels;

    public class FlightStatus : BaseModel
    {
        public string Status { get; set; } = null!;

        public ICollection<Flight> Flights { get; set; } = null!;
    }
}
