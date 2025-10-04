namespace BrowserTravel.Application.Interfaces
{
    using BrowserTravel.Core.Domain.Emuns;
    using BrowserTravel.Core.Domain;

    public interface ISearchStrategy
    {
        SearchType SearchType { get; }
        Task<IEnumerable<Vehicle>> SearchAsync(string pickupLocation, string dropoffLocation);
    }
}
