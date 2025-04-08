using ConsoleApp1.Models.BaseModels;

namespace ConsoleApp1.Models
{
    public class Passanger : BaseModel
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public ICollection<Ticket> Tickets { get; set; }
    }
}
