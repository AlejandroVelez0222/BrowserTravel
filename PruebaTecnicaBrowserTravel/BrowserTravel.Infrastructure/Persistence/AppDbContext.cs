namespace BrowserTravel.Infrastructure.Persistence
{
    using BrowserTravel.Core.Domain;
    using Microsoft.EntityFrameworkCore;

    public class AppDbContext : DbContext
    {
        public DbSet<Vehicle> Vehicles => Set<Vehicle>();
        public DbSet<VehicleLocation> VehicleLocations => Set<VehicleLocation>();

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Vehicle>(entity =>
            {
                entity.HasKey(v => v.Id);
                entity.HasIndex(v => v.CardPlateId).IsUnique();
            });

            modelBuilder.Entity<VehicleLocation>(entity =>
            {
                entity.HasKey(l => l.Id);

                entity.HasOne(l => l.Vehicle)
                      .WithMany(v => v.Locations)
                      .HasForeignKey(l => l.CardPlateId)
                      .HasPrincipalKey(v => v.CardPlateId); 
            });

            modelBuilder.Entity<Vehicle>().HasData(
                new Vehicle
                {
                    Id = Guid.NewGuid(),
                    CardPlateId = "ABC123",
                    Brand = "Toyota",
                    Model = "Corolla",
                    Year = 2020,
                    Category = "Sedan",
                    Market = "LATAM",
                    PricePerDay = 150000
                },
                new Vehicle
                {
                    Id = Guid.NewGuid(),
                    CardPlateId = "XYZ789",
                    Brand = "Mazda",
                    Model = "CX-5",
                    Year = 2022,
                    Category = "SUV",
                    Market = "LATAM",
                    PricePerDay = 220000
                },
                new Vehicle
                {
                    Id = Guid.NewGuid(),
                    CardPlateId = "JKL456",
                    Brand = "Chevrolet",
                    Model = "Spark GT",
                    Year = 2019,
                    Category = "Hatchback",
                    Market = "LATAM",
                    PricePerDay = 120000
                },
                new Vehicle
                {
                    Id = Guid.NewGuid(),
                    CardPlateId = "QWE321",
                    Brand = "Ford",
                    Model = "Ranger",
                    Year = 2021,
                    Category = "Pickup",
                    Market = "LATAM",
                    PricePerDay = 300000
                }
            );

            modelBuilder.Entity<VehicleLocation>().HasData(
                new VehicleLocation
                {
                    Id = Guid.NewGuid(),
                    CardPlateId = "ABC123",
                    Location = "Bogotá",
                    IsAvailable = true
                },
                new VehicleLocation
                {
                    Id = Guid.NewGuid(),
                    CardPlateId = "ABC123",
                    Location = "Medellín",
                    IsAvailable = true
                },
                new VehicleLocation
                {
                    Id = Guid.NewGuid(),
                    CardPlateId = "XYZ789",
                    Location = "Bogotá",
                    IsAvailable = false
                },
                new VehicleLocation
                {
                    Id = Guid.NewGuid(),
                    CardPlateId = "XYZ789",
                    Location = "Cartagena",
                    IsAvailable = true
                },
                new VehicleLocation
                {
                    Id = Guid.NewGuid(),
                    CardPlateId = "JKL456",
                    Location = "Medellín",
                    IsAvailable = true
                },
                new VehicleLocation
                {
                    Id = Guid.NewGuid(),
                    CardPlateId = "JKL456",
                    Location = "Cali",
                    IsAvailable = false
                },
                new VehicleLocation
                {
                    Id = Guid.NewGuid(),
                    CardPlateId = "QWE321",
                    Location = "Bogotá",
                    IsAvailable = true
                },
                new VehicleLocation
                {
                    Id = Guid.NewGuid(),
                    CardPlateId = "QWE321",
                    Location = "Barranquilla",
                    IsAvailable = true
                }
            );

        }
    }
}
