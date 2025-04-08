namespace ConsoleApp1.Models
{
    using ConsoleApp1.Models.BaseModels;

    public class Flight : BaseModel
    {
        public int FlightDuration { get; set; }

        public DateTimeOffset FlightDate { get; set; }

        public ushort PassengersCount { get; set; }

        public ICollection<Crew> Crews { get; set; } = new List<Crew>();

        public ICollection<FlightsStatusChanges> FlightsStatusChanges { get; set; } = new List<FlightsStatusChanges>();

        public ICollection<Passanger> Passangers { get; set; } = new List<Passanger>();
    }
}
