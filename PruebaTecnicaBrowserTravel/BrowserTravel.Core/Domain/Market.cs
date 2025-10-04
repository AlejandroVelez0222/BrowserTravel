namespace BrowserTravel.Core.Domain
{
    using BrowserTravel.Core.Domain.Rules;

    public class Market
    {
        public Guid Id { get; set; }
        public required string Name { get; set; }

        public ICollection<MarketRule> Rules { get; set; } = new List<MarketRule>();
        public ICollection<Vehicle> Vehicles { get; set; } = new List<Vehicle>();
    }
}
