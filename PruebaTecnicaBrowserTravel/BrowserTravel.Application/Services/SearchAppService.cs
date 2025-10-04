namespace BrowserTravel.Application.Services
{
    using BrowserTravel.Application.Dtos;
    using BrowserTravel.Application.Interfaces;
    public class SearchAppService : ISearchAppService
    {
        private readonly IVehicleRepository _repo;
        public SearchAppService(IVehicleRepository repo) => _repo = repo;


        public async Task<IEnumerable<VehicleDto>> Search(string pickup, string ret)
        {
            var vehicles = await _repo.GetAvailableVehicles(pickup, ret);
            return vehicles.Select(v => new VehicleDto(v.Id,v.CardPlateId, v.Brand, v.Model, v.Year, v.Category, v.Market, v.PricePerDay));
        }
    }
}
