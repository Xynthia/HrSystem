using HRSystem.Dtos.Declaratie;
using HRSystem.Services.DeclaratieService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HRSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeclaratieController : ControllerBase
    {
        public IDeclaratieService _declaratieService { get; }

        public DeclaratieController(IDeclaratieService declaratieService)
        {
            _declaratieService = declaratieService;
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<GetDeclaratieDto>>> Get()
        {
            return Ok(_declaratieService.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<GetDeclaratieDto>>> GetSingleDeclaratie(int id)
        {
            return Ok(_declaratieService.GetById(id));
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<GetDeclaratieDto>>> AddDeclaratie(AddDeclaratieDto newDeclaratie)
        {
            return Ok(_declaratieService.AddDeclaratie(newDeclaratie));
        }

        [HttpPut]
        public async Task<ActionResult<ServiceResponse<GetDeclaratieDto>>> UpdateDeclaratie(UpdateDeclaratieDto updatedDeclaratie)
        {
            var serviceResponse = await _declaratieService.UpdateDeclaratie(updatedDeclaratie);
            if (serviceResponse.Data == null)
            {
                return NotFound(serviceResponse);
            }
            return Ok(serviceResponse);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ServiceResponse<GetDeclaratieDto>>> Delete(int id)
        {
            var serviceResponse = await _declaratieService.DeleteDeclaratie(id);
            if (serviceResponse.Data == null)
            {
                return NotFound(serviceResponse);
            }
            return Ok(serviceResponse);
        }

        [HttpPut("Goedkeuring")]
        public async Task<ActionResult<ServiceResponse<GetDeclaratieDto>>> UpdateGoedKeuring(UpdateDeclaratieDto updatedDeclaratie)
        {
            var serviceResponse = await _declaratieService.UpdateGoedKeuring(updatedDeclaratie);
            if (serviceResponse.Data == null)
            {
                return NotFound(serviceResponse);
            }
            return Ok(serviceResponse);    
        }
    }
}
