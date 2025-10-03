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

            modelBuilder.Entity<Vehicle>(eb =>
            {
                eb.HasKey(v => v.Id);
                eb.HasMany(v => v.Locations).WithOne().HasForeignKey("VehicleId");
            });
        }
    }
}
