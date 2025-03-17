namespace Warehouse.Data.Models
{
    using Microsoft.EntityFrameworkCore;

    public class WarehouseContext : DbContext
    {
        public WarehouseContext()
        {

        }

        public WarehouseContext(DbContextOptions<WarehouseContext> options)
            : base(options) 
        {

        }

        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Buyer> Buyers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(DbConfiguration.ConnectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>()
                .HasMany(p => p.Buyers)
                .WithOne(b => b.Product)
                .HasForeignKey(b => b.ProductId)
                .OnDelete(DeleteBehavior.Cascade); ;
        }
    }
}