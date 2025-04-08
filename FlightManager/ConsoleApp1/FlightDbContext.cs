namespace ConsoleApp1
{
    using Microsoft.EntityFrameworkCore;
    using Models;

    public class FlightDbContext : DbContext
    {
        public DbSet<Airplane> Airplanes { get; set; }

        public DbSet<Airport> Airports { get; set; }

        public DbSet<City> Cities { get; set; }

        public DbSet<Continent> Continents { get; set; }

        public DbSet<Country> Countries { get; set; }

        public DbSet<Crew> Crews { get; set; }

        public DbSet<Flight> Flights { get; set; }

        public DbSet<FlightsStatusChanges> FlightsStatusChanges { get; set; }

        public DbSet<FlightStatus> FlightStatus { get; set; }

        public DbSet<Passanger> Passangers { get; set; }

        public DbSet<PayRoll> PayRolls { get; set; }

        public DbSet<Role> Roles { get; set; }

        public DbSet<Ticket> Tickets { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=DAVID\\SQLEXPRESS;Database=FlightManager;Trusted_Connection=True;TrustServerCertificate=True;");

            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Airport>()
                .HasOne(a => a.City)
                .WithMany(c => c.Airports)
                .HasForeignKey(a => a.CityId);

            modelBuilder.Entity<FlightsStatusChanges>()
                .HasOne(fsc => fsc.Flight)
                .WithMany(f => f.FlightsStatusChanges)
                .HasForeignKey(fsc => fsc.FlightId);

            modelBuilder.Entity<Flight>()
                .HasMany(f => f.Crews)
                .WithMany();

            modelBuilder.Entity<Ticket>()
                .HasOne<Flight>()
                .WithMany()
                .HasForeignKey(t => t.FlightId);

        }
    }
}
