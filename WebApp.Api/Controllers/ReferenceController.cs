using Microsoft.AspNetCore.Mvc;
using WebApp.Application.Dtos.referenceStandared;
using WebApp.Application.Services;

namespace WebApp.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ReferenceController : ControllerBase
    {
        private readonly ReferenceService _referenceService;

        public ReferenceController(ReferenceService service)
        {
            _referenceService = service;
        }


        [HttpPost("Add")]
        public async Task<ActionResult> AddReference([FromBody]string reference)
        {
            if (reference != null)
            {
                try {
                    var dto = new AddReferenceDto() { Title = reference };
                    await _referenceService.AddAsync(dto);
                    return Ok(new { value = reference });
                }
                catch(Exception ex)
                {
                    return StatusCode(500, new { Message = "An error occurred while adding the reference." });
                }    
            }
            return BadRequest(new {Message ="Invalid Reference."});  
        }



    }
}
