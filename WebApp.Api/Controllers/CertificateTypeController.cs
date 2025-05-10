using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApp.Application.Dtos.certtificateType;
using WebApp.Application.Services;
using WebApp.Core.Interfaces;
using WebApp.Core.models;
using WebApp.Infrastructure.persistence;

namespace WebApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CertificateTypeController : ControllerBase
    {
        private readonly CertificateTypeService _cerTypeService;

        public CertificateTypeController(CertificateTypeService cerTypeService)
        {
          _cerTypeService = cerTypeService;
        }

       
        
        [HttpPost("AddType")]
        public async Task<ActionResult<CertificateType>> AddCertificateType(AddCerTypeDto dto)
        {
           await _cerTypeService.AddAsync(dto);
           await _cerTypeService.SaveChangesAsync();

            return Created();
        }

      
    }
}
