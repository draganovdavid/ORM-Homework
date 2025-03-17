namespace Warehouse.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Buyer
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(100)]
        public string? Name { get; set; }

        public int ProductId { get; set; }
        public Product Product { get; set; } = null!;
    }
}
