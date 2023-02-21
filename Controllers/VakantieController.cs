using HRSystem.Dtos.Vakantie;
using HRSystem.Services.VakantieService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HRSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VakantieController : ControllerBase
    {
        public IVakantieService _vakantieService { get; }

        public VakantieController(IVakantieService vakantieService)
        {
            _vakantieService = vakantieService;
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<GetVakantieDto>>>> GetAllVakantie()
        {
            return Ok(await _vakantieService.GetAllVakantie());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<GetVakantieDto>>> GetSingleVakantie(int id)
        {
            return Ok(await _vakantieService.GetVakantieById(id));
        }

        [HttpGet("goedgekeurd")]
        public async Task<ActionResult<ServiceResponse<GetVakantieDto>>> GetAllGoedKeuring()
        {
            return Ok(await _vakantieService.GetAllGoedKeuring());
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<List<GetVakantieDto>>>> AddVakantie(AddVakantieDto newVakantie)
        {
            return Ok(await _vakantieService.AddVakantie(newVakantie));
        }

        [HttpPut]
        public async Task<ActionResult<ServiceResponse<GetVakantieDto>>> UpdateVakantie(int id, UpdateVakantieDto updatedVakantie)
        {
            var serviceResponse = await _vakantieService.UpdateVakantie(id, updatedVakantie);
            if(serviceResponse.Data == null)
            {
               
                return NotFound(serviceResponse);
            }
            return Ok(serviceResponse);
        }

        [HttpPut("foutkeuren")]
        public async Task<ActionResult<ServiceResponse<GetVakantieDto>>> DeclaratieFoutKeuren(int id, UpdateKeuringVakantieDto updatedKeuring)
        {
            var serviceResponse = await _vakantieService.UpdateKeuring(id, updatedKeuring, false);
            if (serviceResponse.Data == null)
            {
                return NotFound(serviceResponse);
            }
            return Ok(serviceResponse);
        }

        [HttpPut("goedkeuren")]
        public async Task<ActionResult<ServiceResponse<GetVakantieDto>>> DeclaratieGoedKeuren(int id, UpdateKeuringVakantieDto updatedKeuring)
        {
            var serviceResponse = await _vakantieService.UpdateKeuring(id, updatedKeuring, true);
            if (serviceResponse.Data == null)
            {
                return NotFound(serviceResponse);
            }
            return Ok(serviceResponse);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ServiceResponse<GetVakantieDto>>> DeleteVakantie(int id)
        {
            var serviceResponse = await _vakantieService.DeleteVakantie(id);
            if (serviceResponse.Data == null)
            {
                return NotFound(serviceResponse);
            }
            return Ok(serviceResponse);
        }
    }
}
