namespace PruebaTecnicaBrowserTravel.Api.Controllers
{
    using BrowserTravel.Application.Dtos;
    using BrowserTravel.Application.Interfaces;
    using Microsoft.AspNetCore.Mvc;

    [ApiController]
    [Route("api/[controller]")]
    public class SearchController : ControllerBase
    {
        private readonly ISearchAppService _service;

        public SearchController(ISearchAppService service)
        {
            _service = service;
        }

        [HttpPost("search")]
        public async Task<IActionResult> SearchVehicles([FromBody] SearchRequest request)
        {
            var result = await _service.SearchAsync(request.SearchType, request.PickupLocation, request.DropoffLocation);
            return Ok(result);
        }
    }
}
