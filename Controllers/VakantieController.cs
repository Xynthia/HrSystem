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

        [HttpGet("GetAllVakanties")]
        public async Task<ActionResult<ServiceResponse<List<GetVakantieDto>>>> GetAllVakantie()
        {
            return Ok(_vakantieService.GetAllVakantie());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<GetVakantieDto>>> GetSingleVakantie(int id)
        {
            return Ok(_vakantieService.GetVakantieById(id));
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<List<GetVakantieDto>>>> AddVakantie(AddVakantieDto newVakantie)
        {
            return Ok(_vakantieService.AddVakantie(newVakantie));
        }

        [HttpPut]
        public async Task<ActionResult<ServiceResponse<GetVakantieDto>>> UpdateVakantie(UpdateVakantieDto updatedVakantie)
        {
            var serviceResponse = await _vakantieService.UpdateVakantie(updatedVakantie);
            if(serviceResponse.Data == null)
            {
               
                return NotFound(serviceResponse);
            }
            return Ok(serviceResponse);
        }

        [HttpPut("GoedKeuring")]
        public async Task<ActionResult<ServiceResponse<GetVakantieDto>>> UpdateGoedKeuring(UpdateVakantieDto updatedVakantie)
        {
            var serviceResponse = await _vakantieService.updateGoedKeuring(updatedVakantie);
            if(serviceResponse?.Data == null)
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
