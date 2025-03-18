namespace Warehouse.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Product
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; } = null!;

        public virtual ICollection<Buyer> Buyers { get; set; }
            = new HashSet<Buyer>();
    }
}
