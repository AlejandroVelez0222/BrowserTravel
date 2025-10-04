namespace PruebaTecnicaBrowserTravel.Api.Controllers
{
    using BrowserTravel.Application.Interfaces;
    using Microsoft.AspNetCore.Mvc;

    [ApiController]
    [Route("api/[controller]")]
    public class SearchController : ControllerBase
    {
        private readonly ISearchAppService _service;
        public SearchController(ISearchAppService service) => _service = service;


        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] string pickupLocation, [FromQuery] string returnLocation)
        {
            if (string.IsNullOrWhiteSpace(pickupLocation) || string.IsNullOrWhiteSpace(returnLocation))
                return BadRequest("pickupLocation y returnLocation son obligatorios");


            var result = await _service.Search(pickupLocation, returnLocation);
            return Ok(result);
        }
    }
}
