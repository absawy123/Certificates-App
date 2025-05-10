using Microsoft.AspNetCore.Mvc;
using WebApp.Application.Dtos.certificateType;
using WebApp.Application.Services;

namespace WebApp.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class InspectedItemController : ControllerBase
    {
        private readonly InspectedItemService _service;
        public InspectedItemController(InspectedItemService service)
        {
            _service = service;
        }


        [HttpPost("Add")]
        public async Task<ActionResult> AddItem([FromBody] string equipmentName)
        {
            if (equipmentName != null)
            {
                var dto = new AddItemDto() { Name = equipmentName };
                await _service.AddAsync(dto);
                return Ok(new { value = equipmentName });
            }
            return BadRequest(new { Message = "Invalid Equipment Name." });
        }
    }
}
