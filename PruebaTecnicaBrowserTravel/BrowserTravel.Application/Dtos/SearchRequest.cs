namespace BrowserTravel.Application.Dtos
{
    using BrowserTravel.Core.Domain.Emuns;

    public class SearchRequest
    {
        public SearchType SearchType { get; set; }
        public string PickupLocation { get; set; } = null!;
        public string DropoffLocation { get; set; } = null!;
    }
}
