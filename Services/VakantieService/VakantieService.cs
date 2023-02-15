using AutoMapper;
using HRSystem.Dtos.Vakantie;

namespace HRSystem.Services.VakantieService
{
    public class VakantieService : IVakantieService
    {
        
        private readonly DataContext _dataContext;
        private readonly IMapper _mapper;

        public VakantieService(DataContext dataContext, IMapper mapper)
        {
            _dataContext = dataContext;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<List<GetVakantieDto>>> AddVakantie(AddVakantieDto newVakantie)
        {
            var serviceResponse = new ServiceResponse<List<GetVakantieDto>>();
            Vakantie vakantie = _mapper.Map<Vakantie>(newVakantie);
            _dataContext.Add(vakantie);
            _dataContext.SaveChanges();

            serviceResponse.Data = _dataContext.Vakantie.Select(v => _mapper.Map<GetVakantieDto>(v)).ToList();
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetVakantieDto>>> DeleteVakantie(int id)
        {
            ServiceResponse<List<GetVakantieDto>> serviceResponse = new ServiceResponse<List<GetVakantieDto>>();

            try
            {
                Vakantie vakantie = _dataContext.Vakantie.First(v => v.Id == id);
                _dataContext.Vakantie.Remove(vakantie);
                _dataContext.SaveChanges();

                serviceResponse.Data = _dataContext.Vakantie.Select(v => _mapper.Map<GetVakantieDto>(v)).ToList();
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
                Data = _dataContext.Vakantie.Select(v => _mapper.Map<GetVakantieDto>(v)).ToList()
            };
        }

        public async Task<ServiceResponse<GetVakantieDto>> GetVakantieById(int id)
        {
            var serviceResponse = new ServiceResponse<GetVakantieDto>();
            var vakantie = _dataContext.Vakantie.FirstOrDefault(c => c.Id == id);
            serviceResponse.Data = _mapper.Map<GetVakantieDto>(vakantie);
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetVakantieDto>> updateGoedKeuring(UpdateVakantieDto updatedVakantie)
        {
            ServiceResponse<GetVakantieDto> serviceResponse = new ServiceResponse<GetVakantieDto>();
            
            try
            {
                Vakantie vakantie = _dataContext.Vakantie.FirstOrDefault(v => v.Id == updatedVakantie.Id);

                vakantie.GoedKeuring = updatedVakantie.GoedKeuring;

                _dataContext.SaveChanges();

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
            Vakantie vakantie = _dataContext.Vakantie.FirstOrDefault(v => v.Id == updatedVakantie.Id);

            try
            {
                vakantie.Naam = updatedVakantie.Naam;
                vakantie.BeginDatum = updatedVakantie.BeginDatum;
                vakantie.EindDatum = updatedVakantie.EindDatum;
                vakantie.AanvraagDatum = updatedVakantie.AanvraagDatum;
                vakantie.GoedKeuring = updatedVakantie.GoedKeuring;

                _dataContext.SaveChanges();

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
