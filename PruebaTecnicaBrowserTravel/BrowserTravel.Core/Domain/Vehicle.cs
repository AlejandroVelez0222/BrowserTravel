namespace BrowserTravel.Core.Domain
{
    public class Vehicle
    {
        public Guid Id { get; set; }
        public required string CardPlateId { get; set; }
        public string Brand { get; set; } = null!;
        public string Model { get; set; } = null!;
        public int Year { get; set; } = 1999;
        public string Category { get; set; } = null!; // e.g. Economy, SUV
        public string Market { get; set; } = null!; // mercado / regió
        public double PricePerDay { get; set; } = 0.0;
        public IEnumerable<VehicleLocation> Locations { get; set; } = new List<VehicleLocation>();
    }
}
