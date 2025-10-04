namespace BrowserTravel.Application.Interfaces
{
    using BrowserTravel.Application.Dtos;
    public interface ISearchAppService
    {
        Task<IEnumerable<VehicleDto>> Search(string pickup, string ret);
    }
}
