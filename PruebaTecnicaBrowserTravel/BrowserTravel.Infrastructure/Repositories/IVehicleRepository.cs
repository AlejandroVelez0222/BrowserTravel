namespace BrowserTravel.Infrastructure.Repositories
{
    using BrowserTravel.Core.Domain;
    public interface IVehicleRepository
    {
        Task<IEnumerable<Vehicle>> GetAvailableVehicles(string pickupLocation, string returnLocation, CancellationToken cancellationToken = default);
    }
}
