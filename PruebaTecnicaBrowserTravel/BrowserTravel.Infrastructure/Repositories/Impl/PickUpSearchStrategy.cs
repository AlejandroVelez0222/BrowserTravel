namespace BrowserTravel.Infrastructure.Repositories.Impl
{
    using BrowserTravel.Application.Interfaces;
    using BrowserTravel.Core.Domain;
    using BrowserTravel.Core.Domain.Emuns;
    using BrowserTravel.Infrastructure.Persistence;
    using System.Collections.Generic;
    using Microsoft.EntityFrameworkCore;

    public class PickUpSearchStrategy : ISearchStrategy
    {
        private readonly AppDbContext _context;
        public SearchType SearchType => SearchType.DirectAvailability;

        public PickUpSearchStrategy(AppDbContext context)
        {
            _context = context;
        }


        public async Task<IEnumerable<Vehicle>> SearchAsync(string pickupLocation, string dropoffLocation)
        {
            if (string.IsNullOrEmpty(pickupLocation))
                throw new ArgumentException("Debe especificar una localidad de recogida");

            return await _context.Vehicles
                .Include(v => v.Locations)
                .Where(v => v.Locations.Any(l => l.Location == pickupLocation && l.IsAvailable))
                .ToListAsync();
        }

    }
}
