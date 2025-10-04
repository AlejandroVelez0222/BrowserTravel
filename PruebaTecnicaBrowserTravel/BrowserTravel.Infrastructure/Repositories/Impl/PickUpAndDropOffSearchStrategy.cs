namespace BrowserTravel.Infrastructure.Repositories.Impl
{
    using BrowserTravel.Application.Interfaces;
    using BrowserTravel.Core.Domain;
    using BrowserTravel.Core.Domain.Emuns;
    using BrowserTravel.Infrastructure.Persistence;
    using System.Collections.Generic;
    using Microsoft.EntityFrameworkCore;

    public class PickUpAndDropOffSearchStrategy : ISearchStrategy
    {
        private readonly AppDbContext _context;
        public SearchType SearchType => SearchType.Advanced;

        public PickUpAndDropOffSearchStrategy(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Vehicle>> SearchAsync(string pickupLocation, string dropoffLocation)
        {
            if (string.IsNullOrEmpty(pickupLocation) || string.IsNullOrEmpty(dropoffLocation))
                throw new ArgumentException("Debe especificar localidad de recogida y devolución");

            return await _context.Vehicles
                .Include(v => v.Locations)
                .Where(v =>
                    v.Locations.Any(l => l.Location == pickupLocation && l.IsAvailable) &&
                    v.Locations.Any(l => l.Location == dropoffLocation)
                )
                .ToListAsync();
        }

    }
}
