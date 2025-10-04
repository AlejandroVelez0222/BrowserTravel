namespace BrowserTravel.Infrastructure.Persistence
{
    using BrowserTravel.Core.Domain;
    using BrowserTravel.Core.Domain.Rules;
    using Microsoft.EntityFrameworkCore;

    public class AppDbContext : DbContext
    {
        public DbSet<Vehicle> Vehicles => Set<Vehicle>();
        public DbSet<VehicleLocation> VehicleLocations => Set<VehicleLocation>();
        public DbSet<Market> Markets => Set<Market>();
        public DbSet<MarketRule> MarketRules => Set<MarketRule>();

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configuración de llaves y relaciones
            modelBuilder.Entity<Market>(entity =>
            {
                entity.HasKey(m => m.Id);
            });

            modelBuilder.Entity<MarketRule>(entity =>
            {
                entity.HasKey(r => r.Id);
                entity.HasOne(r => r.Market)
                      .WithMany(m => m.Rules)
                      .HasForeignKey(r => r.MarketId);
            });

            modelBuilder.Entity<Vehicle>(entity =>
            {
                entity.HasKey(v => v.Id);
                entity.HasIndex(v => v.CardPlateId).IsUnique();
                entity.HasOne(v => v.Market)
                      .WithMany(m => m.Vehicles)
                      .HasForeignKey(v => v.MarketId);
                entity.Property(v => v.PricePerDay).HasColumnType("decimal(18,2)");
                entity.HasMany(v => v.Locations)          // relación con Locations
         .WithOne(l => l.Vehicle)
         .HasForeignKey(l => l.CardPlateId);
            });

            modelBuilder.Entity<VehicleLocation>(entity =>
            {

                entity.HasOne(l => l.Vehicle)
                      .WithMany(v => v.Locations)
                      .HasPrincipalKey(v => v.CardPlateId)
                      .HasForeignKey(l => l.CardPlateId);
            });

            var latamMarketId = Guid.Parse("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa");
            var euMarketId = Guid.Parse("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb");

            modelBuilder.Entity<Market>().HasData(
                new Market { Id = latamMarketId, Name = "LATAM" },
                new Market { Id = euMarketId, Name = "EU" }
            );

            // MarketRules
            modelBuilder.Entity<MarketRule>().HasData(
                // LATAM
                new MarketRule { Id = Guid.Parse("11111111-1111-1111-1111-111111111111"), MarketId = latamMarketId, CustomerLocation = "Bogotá", RentalLocation = "Medellín" },
                new MarketRule { Id = Guid.Parse("11111111-1111-1111-1111-111111111112"), MarketId = latamMarketId, CustomerLocation = "Cali", RentalLocation = "Cartagena" },
                new MarketRule { Id = Guid.Parse("11111111-1111-1111-1111-111111111113"), MarketId = latamMarketId, CustomerLocation = "Medellín", RentalLocation = "Bogotá" },
                new MarketRule { Id = Guid.Parse("11111111-1111-1111-1111-111111111114"), MarketId = latamMarketId, CustomerLocation = "Cartagena", RentalLocation = "Cali" },

                // EU
                new MarketRule { Id = Guid.Parse("22222222-2222-2222-2222-222222222221"), MarketId = euMarketId, CustomerLocation = "Paris", RentalLocation = "Lyon" },
                new MarketRule { Id = Guid.Parse("22222222-2222-2222-2222-222222222222"), MarketId = euMarketId, CustomerLocation = "Berlin", RentalLocation = "Munich" },
                new MarketRule { Id = Guid.Parse("22222222-2222-2222-2222-222222222223"), MarketId = euMarketId, CustomerLocation = "Madrid", RentalLocation = "Barcelona" },
                new MarketRule { Id = Guid.Parse("22222222-2222-2222-2222-222222222224"), MarketId = euMarketId, CustomerLocation = "Rome", RentalLocation = "Florence" }
            );

            // Vehicles
            var vehicles = new List<Vehicle>
    {
        new Vehicle { Id = Guid.Parse("33333333-3333-3333-3333-333333333331"), CardPlateId = "ABC123", Brand = "Toyota", Model = "Corolla", Year = 2020, Category = "Sedan", MarketId = latamMarketId, PricePerDay = 150000 },
        new Vehicle { Id = Guid.Parse("33333333-3333-3333-3333-333333333332"), CardPlateId = "XYZ789", Brand = "Mazda", Model = "CX-5", Year = 2022, Category = "SUV", MarketId = latamMarketId, PricePerDay = 220000 },
        new Vehicle { Id = Guid.Parse("33333333-3333-3333-3333-333333333333"), CardPlateId = "JKL456", Brand = "Chevrolet", Model = "Spark GT", Year = 2019, Category = "Hatchback", MarketId = latamMarketId, PricePerDay = 120000 },
        new Vehicle { Id = Guid.Parse("33333333-3333-3333-3333-333333333334"), CardPlateId = "QWE321", Brand = "Ford", Model = "Ranger", Year = 2021, Category = "Pickup", MarketId = latamMarketId, PricePerDay = 300000 },
        new Vehicle { Id = Guid.Parse("33333333-3333-3333-3333-333333333335"), CardPlateId = "LMN987", Brand = "BMW", Model = "X3", Year = 2021, Category = "SUV", MarketId = euMarketId, PricePerDay = 350000 },
        new Vehicle { Id = Guid.Parse("33333333-3333-3333-3333-333333333336"), CardPlateId = "OPQ654", Brand = "Audi", Model = "A4", Year = 2020, Category = "Sedan", MarketId = euMarketId, PricePerDay = 300000 }
    };

            modelBuilder.Entity<Vehicle>().HasData(vehicles);

            // VehicleLocations
            modelBuilder.Entity<VehicleLocation>().HasData(
                // ABC123
                new VehicleLocation { Id = Guid.Parse("44444444-4444-4444-4444-444444444441"), CardPlateId = "ABC123", Location = "Bogotá", IsAvailable = true },
                new VehicleLocation { Id = Guid.Parse("44444444-4444-4444-4444-444444444442"), CardPlateId = "ABC123", Location = "Medellín", IsAvailable = true },

                // XYZ789
                new VehicleLocation { Id = Guid.Parse("44444444-4444-4444-4444-444444444443"), CardPlateId = "XYZ789", Location = "Bogotá", IsAvailable = false },
                new VehicleLocation { Id = Guid.Parse("44444444-4444-4444-4444-444444444444"), CardPlateId = "XYZ789", Location = "Cartagena", IsAvailable = true },

                // JKL456
                new VehicleLocation { Id = Guid.Parse("55555555-5555-5555-5555-555555555551"), CardPlateId = "JKL456", Location = "Medellín", IsAvailable = true },
                new VehicleLocation { Id = Guid.Parse("55555555-5555-5555-5555-555555555552"), CardPlateId = "JKL456", Location = "Cali", IsAvailable = false },

                // QWE321
                new VehicleLocation { Id = Guid.Parse("55555555-5555-5555-5555-555555555553"), CardPlateId = "QWE321", Location = "Bogotá", IsAvailable = true },
                new VehicleLocation { Id = Guid.Parse("55555555-5555-5555-5555-555555555554"), CardPlateId = "QWE321", Location = "Barranquilla", IsAvailable = true },

                // LMN987
                new VehicleLocation { Id = Guid.Parse("66666666-6666-6666-6666-666666666661"), CardPlateId = "LMN987", Location = "Paris", IsAvailable = true },
                new VehicleLocation { Id = Guid.Parse("66666666-6666-6666-6666-666666666662"), CardPlateId = "LMN987", Location = "Lyon", IsAvailable = false },

                // OPQ654
                new VehicleLocation { Id = Guid.Parse("66666666-6666-6666-6666-666666666663"), CardPlateId = "OPQ654", Location = "Berlin", IsAvailable = true },
                new VehicleLocation { Id = Guid.Parse("66666666-6666-6666-6666-666666666664"), CardPlateId = "OPQ654", Location = "Munich", IsAvailable = true }
            );
        }

    }
}
