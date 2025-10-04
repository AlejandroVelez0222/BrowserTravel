namespace BrowserTravel.Application.Interfaces
{
    using BrowserTravel.Core.Domain.Emuns;
    using BrowserTravel.Application.Dtos;

    public interface ISearchAppService
    {
        Task<IEnumerable<VehicleDto>> SearchAsync(SearchType searchType, string pickup, string dropoff);
    }
}
