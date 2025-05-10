using Microsoft.AspNetCore.Mvc;
using WebApp.Application.Dtos.certificateType;
using WebApp.Application.Services;

namespace WebApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationController : ControllerBase
    {
        private readonly LocationService _locationService;
        public LocationController(LocationService locationService)
        {
            _locationService = locationService;
        }



        [HttpPost("AddLocation")]
        public async Task<IActionResult> Add(AddLocationDto dto )
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            await _locationService.AddAsync(dto);
            return Created();
        }







    }
}
