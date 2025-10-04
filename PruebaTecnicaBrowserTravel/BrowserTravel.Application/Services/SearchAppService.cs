namespace BrowserTravel.Application.Services
{
    using BrowserTravel.Application.Dtos;
    using BrowserTravel.Application.Interfaces;
    using BrowserTravel.Core.Domain.Emuns;
    using System.Collections.Generic;

    public class SearchAppService : ISearchAppService
    {
        private readonly Dictionary<SearchType, ISearchStrategy> _strategies;
        public SearchAppService(IEnumerable<ISearchStrategy> strategies)
        {
            _strategies = strategies.ToDictionary(s => s.SearchType, s => s);
        }

        public async Task<IEnumerable<VehicleDto>> SearchAsync(SearchType searchType, string pickup, string dropoff)
        {

            if (!_strategies.TryGetValue(searchType, out var strategy))
                throw new ArgumentException($"Unknown search type: {searchType}");

            var vehicles = await strategy.SearchAsync(pickup, dropoff);
            return vehicles.Select(v => new VehicleDto(v.Id, v.CardPlateId, v.Brand, v.Model, v.Year, v.Category, v.Market.Name, v.PricePerDay));

        }
    }
}
