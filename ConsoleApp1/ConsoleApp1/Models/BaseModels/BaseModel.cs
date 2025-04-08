namespace ConsoleApp1.Models.BaseModels
{
    public class BaseModel : IBaseModel
    {
        public int Id { get; set; }
        public DateTimeOffset CreatedAt { get; set; } 
            = DateTimeOffset.UtcNow;

        public DateTimeOffset? UpdatedAt { get; set; }

        public DateTimeOffset? DeletedAt { get; set; }
    }
}
