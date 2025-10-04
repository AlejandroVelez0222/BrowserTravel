namespace BrowserTravel.Infrastructure.Repositories.Impl
{
    using BrowserTravel.Application.Interfaces;
    using BrowserTravel.Core.Domain.Emuns;
    using BrowserTravel.Core.Domain;
    using BrowserTravel.Infrastructure.Persistence;
    using System.Collections.Generic;
    using Microsoft.EntityFrameworkCore;

    public class MarketSearchStrategy : ISearchStrategy
    {
        private readonly AppDbContext _context;
        public SearchType SearchType => SearchType.Market;

        public MarketSearchStrategy(AppDbContext context) => _context = context;

        public async Task<IEnumerable<Vehicle>> SearchAsync(string pickupLocation, string dropoffLocation)
        {
            var market = await _context.MarketRules
                .FirstOrDefaultAsync(r => r.CustomerLocation == pickupLocation && r.RentalLocation == dropoffLocation);

            if (market == null) return new List<Vehicle>();

            return await _context.Vehicles
                .Where(v => v.MarketId == market.MarketId && v.Locations.Any(l => l.Location == pickupLocation && l.IsAvailable))
                .ToListAsync();
        }
    }
}
