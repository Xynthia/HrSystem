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
            return Ok(await _declaratieService.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<GetDeclaratieDto>>> GetSingleDeclaratie(int id)
        {
            return Ok(await _declaratieService.GetById(id));
        }

        [HttpGet("goedgekeurd")]
        public async Task<ActionResult<ServiceResponse<GetDeclaratieDto>>> GetAllGoedKeuring()
        {
            return Ok(await _declaratieService.GetAllGoedKeuring());
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<GetDeclaratieDto>>> AddDeclaratie(AddDeclaratieDto newDeclaratie)
        {
            return Ok(await _declaratieService.AddDeclaratie(newDeclaratie));
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ServiceResponse<GetDeclaratieDto>>> UpdateDeclaratie(int id, UpdateDeclaratieDto updatedDeclaratie)
        {
            var serviceResponse = await _declaratieService.UpdateDeclaratie(id, updatedDeclaratie);
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

        [HttpPut("foutkeuren")]
        public async Task<ActionResult<ServiceResponse<GetDeclaratieDto>>> DeclaratieFoutKeuren(int id)
        {
            var serviceResponse = await _declaratieService.UpdateKeuring(id, false);
            if (serviceResponse.Data == null)
            {
                return NotFound(serviceResponse);
            }
            return Ok(serviceResponse);    
        }

        [HttpPut("goedkeuren")]
        public async Task<ActionResult<ServiceResponse<GetDeclaratieDto>>> DeclaratieGoedKeuren(int id)
        {
            var serviceResponse = await _declaratieService.UpdateKeuring(id, true);
            if (serviceResponse.Data == null)
            {
                return NotFound(serviceResponse);
            }
            return Ok(serviceResponse);
        }


    }
}
