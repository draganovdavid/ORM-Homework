namespace ConsoleApp1.Models
{
    using ConsoleApp1.Models.BaseModels;
    using ConsoleApp1.Models.Enum;

    public class Ticket : BaseModel
    {
        public decimal TicketPrice { get; set; }

        public TicketType Type { get; set; }

        public ushort SeatNumber  { get; set; }

        public int PayRollId { get; set; }  

        public PayRoll? PayrollId { get; set; }

        public int FlightId { get; set; }

        public int PassangerId { get; set; }
        public Passanger Passanger { get; set; } = null!;
    }
}
