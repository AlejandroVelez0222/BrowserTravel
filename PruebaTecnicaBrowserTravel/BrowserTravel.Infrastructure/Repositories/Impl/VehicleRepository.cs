namespace BrowserTravel.Infrastructure.Repositories.Impl
{
    using BrowserTravel.Core.Domain;
    using BrowserTravel.Infrastructure.Persistence;
    using Microsoft.EntityFrameworkCore;

    public class VehicleRepository : IVehicleRepository
    {
        private readonly AppDbContext _db;
        public VehicleRepository(AppDbContext db)
        {
            _db = db;
        }

        public async Task<IEnumerable<Vehicle>> GetAvailableVehicles(string pickupLocation, string returnLocation, CancellationToken cancellationToken = default)
        {
            // Regla simple: vehículo disponible si tiene al menos una location disponible en pickupLocation
            // y su Market coincide con la combinación de pickup/return (ejemplo simplificado)
            var market = ComputeMarket(pickupLocation, returnLocation);


            return await _db.Vehicles
            .Include(v => v.Locations)
            .Where(v => v.Market == market && v.Locations.Any(l => l.LocationCode == pickupLocation && l.IsAvailable))
            .ToListAsync(cancellationToken);
        }


        private string ComputeMarket(string pickup, string ret)
        {
            // Lógica de ejemplo: concatenación (puedes sustituir por reglas reales)
            return $"{pickup.ToUpperInvariant()}_{ret.ToUpperInvariant()}";
        }


    }
}
