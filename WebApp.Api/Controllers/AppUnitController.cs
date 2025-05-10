using Microsoft.AspNetCore.Mvc;
using WebApp.Core.models;

namespace WebApp.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AppUnitController : ControllerBase
    {

       
        [HttpPost("AddLength")]
        public IActionResult AddLengthUnit([FromBody] string unit)
        {
            if (string.IsNullOrWhiteSpace(unit))
                return BadRequest("Unit cannot be empty.");

            AppUnit.AddLength(unit);
            return Ok(new { Value = unit });
        }

        [HttpPost("AddUnit")]
        public IActionResult AddLoadUnit([FromBody] string unit)
        {
            if (string.IsNullOrWhiteSpace(unit))
                return BadRequest("Unit cannot be empty.");

            var isAdded = AppUnit.AddLoad(unit);
            if(isAdded)
            return Ok(new { Value = unit });

            return BadRequest(new { Message = "This unit has been added before." });
        }

    }
}
