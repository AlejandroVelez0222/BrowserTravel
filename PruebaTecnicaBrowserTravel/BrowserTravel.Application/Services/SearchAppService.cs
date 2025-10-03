namespace BrowserTravel.Application.Services
{
    using BrowserTravel.Application.Dtos;
    using BrowserTravel.Infrastructure.Repositories;
    public class SearchService
    {
        private readonly IVehicleRepository _repo;
        public SearchService(IVehicleRepository repo) => _repo = repo;


        public async Task<IEnumerable<VehicleDto>> Search(string pickup, string ret)
        {
            var vehicles = await _repo.GetAvailableVehicles(pickup, ret);
            return vehicles.Select(v => new VehicleDto(v.Id, v.Make, v.Model, v.Category, v.Market));
        }
    }
}
