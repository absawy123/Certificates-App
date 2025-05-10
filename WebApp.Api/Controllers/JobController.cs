using Microsoft.AspNetCore.Mvc;
using WebApp.Application.Dtos.certificateType;
using WebApp.Application.Services;

namespace WebApp.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class JobController : ControllerBase
    {
        private readonly JobService _jobService;

        public JobController(JobService jobService)
        {
            _jobService = jobService;
        }


        [HttpPost("AddJob")]
        public async Task<ActionResult> AddAsync([FromBody]AddJobDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            try
            {
                await _jobService.AddAsync(dto);
                return Ok(new { Success = true, Message = "Job added successfully" });

            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Success = false, Message = "An error occurred while adding the job.", Error = ex.Message });

            }

        }




    }
}
