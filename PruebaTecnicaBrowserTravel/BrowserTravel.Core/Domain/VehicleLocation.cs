namespace BrowserTravel.Core.Domain
{
    public class VehicleLocation
    {
        public Guid Id { get; set; }
        public Guid VehicleId { get; set; }
        public string LocationCode { get; set; } = null!; // p.e. city code
        public bool IsAvailable { get; set; }
    }
}
