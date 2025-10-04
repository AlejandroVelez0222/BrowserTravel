namespace BrowserTravel.Core.Domain
{
    public class Vehicle
    {
        public Guid Id { get; set; }
        public required string CardPlateId { get; set; }
        public string Brand { get; set; } = null!;
        public string Model { get; set; } = null!;
        public int Year { get; set; } = 1999;
        public string Category { get; set; } = null!; //  Economy, SUV
        public double PricePerDay { get; set; } = 0.0;
        public Guid MarketId { get; set; }


        public Market Market { get; set; } = null!;
        public ICollection<VehicleLocation> Locations { get; set; } = new List<VehicleLocation>();
    }
}
