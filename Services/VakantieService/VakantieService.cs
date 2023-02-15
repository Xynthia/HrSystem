using AutoMapper;
using HRSystem.Dtos.Vakantie;

namespace HRSystem.Services.VakantieService
{
    public class VakantieService : IVakantieService
    {
        private static List<Vakantie> vakanties = new List<Vakantie>()
        {
            new Vakantie(),
            new Vakantie { Id = 1, Naam = "Mei Vakantie"}
        };
        private readonly IMapper _mapper;

        public VakantieService(IMapper mapper)
        {
            _mapper = mapper;
        }

        public async Task<ServiceResponse<List<GetVakantieDto>>> AddVakantie(AddVakantieDto newVakantie)
        {
            var serviceResponse = new ServiceResponse<List<GetVakantieDto>>();
            Vakantie vakantie = _mapper.Map<Vakantie>(newVakantie);
            vakantie.Id = vakanties.Max(v => v.Id) + 1;
            serviceResponse.Data = vakanties.Select(v => _mapper.Map<GetVakantieDto>(v)).ToList();
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetVakantieDto>>> DeleteVakantie(int id)
        {
            ServiceResponse<List<GetVakantieDto>> serviceResponse = new ServiceResponse<List<GetVakantieDto>>();

            try
            {
                Vakantie vakantie = vakanties.First(v => v.Id == id);
                vakanties.Remove(vakantie);

                serviceResponse.Data = vakanties.Select(v => _mapper.Map<GetVakantieDto>(v)).ToList();
            }
            catch (Exception ex)
            {
                serviceResponse.Succes = false;
                serviceResponse.Message = ex.Message;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetVakantieDto>>> GetAllVakantie()
        {
            return new ServiceResponse<List<GetVakantieDto>> 
            { 
                Data = vakanties.Select(v => _mapper.Map<GetVakantieDto>(v)).ToList()
            };
        }

        public async Task<ServiceResponse<GetVakantieDto>> GetVakantieById(int id)
        {
            var serviceResponse = new ServiceResponse<GetVakantieDto>();
            var vakantie = vakanties.FirstOrDefault(c => c.Id == id);
            serviceResponse.Data = _mapper.Map<GetVakantieDto>(vakantie);
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetVakantieDto>> updateGoedKeruing(UpdateVakantieDto updatedVakantie)
        {
            ServiceResponse<GetVakantieDto> serviceResponse = new ServiceResponse<GetVakantieDto>();
            Vakantie vakantie = vakanties.FirstOrDefault(v => v.Id == updatedVakantie.Id);

            try
            {
                vakantie.GoedKeuring = updatedVakantie.GoedKeuring;

                serviceResponse.Data = _mapper.Map<GetVakantieDto>(vakantie);
            }
            catch (Exception ex)
            {
                serviceResponse.Succes = false;
                serviceResponse.Message = ex.Message;
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetVakantieDto>> UpdateVakantie(UpdateVakantieDto updatedVakantie)
        {
            ServiceResponse<GetVakantieDto> serviceResponse = new ServiceResponse<GetVakantieDto>();
            Vakantie vakantie = vakanties.FirstOrDefault(v => v.Id == updatedVakantie.Id);

            try
            {
                vakantie.Naam = updatedVakantie.Naam;
                vakantie.BeginDatum = updatedVakantie.BeginDatum;
                vakantie.EindDatum = updatedVakantie.EindDatum;
                vakantie.AanvraagDatum = updatedVakantie.AanvraagDatum;
                vakantie.GoedKeuring = updatedVakantie.GoedKeuring;

                serviceResponse.Data = _mapper.Map<GetVakantieDto>(vakantie);
            }
            catch (Exception ex)
            {
                serviceResponse.Succes = false;
                serviceResponse.Message = ex.Message;
            }

            return serviceResponse;
        }

        
    }
}
