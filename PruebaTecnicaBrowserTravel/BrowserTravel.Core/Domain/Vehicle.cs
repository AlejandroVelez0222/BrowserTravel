namespace BrowserTravel.Core.Domain
{
    public class Vehicle
    {
        public Guid Id { get; set; }
        public string Make { get; set; } = null!;
        public string Model { get; set; } = null!;
        public string Category { get; set; } = null!; // e.g. Economy, SUV
        public string Market { get; set; } = null!; // mercado / región
        public IEnumerable<VehicleLocation> Locations { get; set; } = new List<VehicleLocation>();
    }
}
