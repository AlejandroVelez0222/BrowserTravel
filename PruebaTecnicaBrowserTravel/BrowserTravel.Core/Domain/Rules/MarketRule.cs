namespace BrowserTravel.Core.Domain.Rules
{   
    public class MarketRule
    {
        public Guid Id { get; set; }
        public Guid MarketId { get; set; }
        public Market Market { get; set; } = null!;

        public required string CustomerLocation { get; set; }
        public required string RentalLocation { get; set; }
    }
}
