namespace BrowserTravel.Core.Domain
{
    public class VehicleLocation
    {
        public Guid Id { get; set; }
        public  required string CardPlateId { get; set; }
        public string Location { get; set; } = null!; // p.e. city code
        public bool IsAvailable { get; set; }

        public Vehicle Vehicle { get; set; } = null!;
    }
}
