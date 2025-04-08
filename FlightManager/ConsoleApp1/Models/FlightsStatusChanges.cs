namespace ConsoleApp1.Models
{
    using ConsoleApp1.Models.BaseModels;

    public class FlightsStatusChanges : BaseModel
    {
        public int FlightId { get; set; }
        public Flight Flight { get; set; } = null!;

        public int FlightStatusId { get; set; }
        public FlightStatus FlightStatus { get; set; } = null!;

        public DateTimeOffset ChangetAt { get; set; }
    }
}
