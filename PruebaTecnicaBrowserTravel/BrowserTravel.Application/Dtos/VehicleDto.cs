namespace BrowserTravel.Application.Dtos
{
    public record VehicleDto(Guid Id, string CardPlateID, string Brand, string Model, int year, string Category, string Market, double PricePerDay);
}
