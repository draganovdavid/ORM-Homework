namespace ConsoleApp1
{
    using System.Diagnostics;
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
            //Debugger.Launch();
            //Seeding the Database with some data
            // Seed Continents
            modelBuilder.Entity<Continent>().HasData(
            new Continent { Id = 1, ContinentName = "Europe" },
            new Continent { Id = 2, ContinentName = "Asia" },
            new Continent { Id = 3, ContinentName = "North America" }
            );

            // Seed Countries
            modelBuilder.Entity<Country>().HasData(
            new Country { Id = 1, CountryName = "Germany", ContinentId = 1 },
            new Country { Id = 2, CountryName = "Japan", ContinentId = 2 },
            new Country { Id = 3, CountryName = "USA", ContinentId = 3 }
            );

            // Seed Cities
            modelBuilder.Entity<City>().HasData(
            new City { Id = 1, CityName = "Berlin", CountryId = 1 },
            new City { Id = 2, CityName = "Tokyo", CountryId = 2 },
            new City { Id = 3, CityName = "New York", CountryId = 3 }
            );

            // Seed Airports
            modelBuilder.Entity<Airport>().HasData(
            new Airport { Id = 1, Name = "Berlin Airport", CityId = 1 },
            new Airport { Id = 2, Name = "Tokyo International", CityId = 2 },
            new Airport { Id = 3, Name = "JFK Airport", CityId = 3 }
            );

            // Seed Airplanes
            modelBuilder.Entity<Airplane>().HasData(
                new Airplane { Id = 1, SeatsCount = 400 },
                new Airplane { Id = 2, SeatsCount = 180 },
                new Airplane { Id = 3, SeatsCount = 350 }
            );

            // Seed Crew
            modelBuilder.Entity<Crew>().HasData(
                new Crew { Id = 1, Name = "John Doe" },
                new Crew { Id = 2, Name = "Jane Smith" },
                new Crew { Id = 3, Name = "Robert Brown" }
            );

            // Seed Flight Statuses
            modelBuilder.Entity<FlightStatus>().HasData(
                new FlightStatus { Id = 1, Status = "On Time" },
                new FlightStatus { Id = 2, Status = "Delayed" },
                new FlightStatus { Id = 3, Status = "Cancelled" }
            );

            // Seed Flights
            modelBuilder.Entity<Flight>().HasData(
                new Flight { Id = 1, FlightDuration = 120, FlightDate = new DateTime(2024, 04, 04), PassengersCount = 200 },
                new Flight { Id = 2, FlightDuration = 720, FlightDate = new DateTime(2024,04,04), PassengersCount = 150 },
                new Flight { Id = 3, FlightDuration = 600, FlightDate = new DateTime(2024, 04, 04), PassengersCount = 180 }
            );

            // Seed Flight Status Changes
            modelBuilder.Entity<FlightsStatusChanges>().HasData(
                new FlightsStatusChanges { Id = 1, FlightId = 1, FlightStatusId = 1, ChangetAt = new DateTime(2024, 04, 08) },
                new FlightsStatusChanges { Id = 2, FlightId = 2, FlightStatusId = 2, ChangetAt = new DateTime(2024, 04, 05) },
                new FlightsStatusChanges { Id = 3, FlightId = 3, FlightStatusId = 3, ChangetAt = new DateTime(2024, 04, 07) }
            );

            // Seed Passengers
            modelBuilder.Entity<Passanger>().HasData(
                new Passanger { Id = 1, Name = "Alice Johnson" },
                new Passanger { Id = 2, Name = "Bob Martinez" },
                new Passanger { Id = 3, Name = "Charlie Williams" }
            );

            // Seed Payroll
            modelBuilder.Entity<PayRoll>().HasData(
                new PayRoll { Id = 1, },
                new PayRoll { Id = 2, },
                new PayRoll { Id = 3 }
            );

            // Seed Roles
            modelBuilder.Entity<Role>().HasData(
                new Role { Id = 1 },
                new Role { Id = 2 },
                new Role { Id = 3 }
            );

            // Seed Tickets
            modelBuilder.Entity<Ticket>().HasData(
                new Ticket { Id = 1, FlightId = 1, PassangerId = 1, TicketPrice = 500 },
                new Ticket { Id = 2, FlightId = 2, PassangerId = 2, TicketPrice = 700 },
                new Ticket { Id = 3, FlightId = 3, PassangerId = 3, TicketPrice = 650 }
            );
            base.OnModelCreating(modelBuilder);
        }
    }
}
