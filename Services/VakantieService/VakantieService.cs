using AutoMapper;
using HRSystem.Dtos.Vakantie;
using Microsoft.EntityFrameworkCore;

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
            await _dataContext.AddAsync(vakantie);
            await _dataContext.SaveChangesAsync();

            serviceResponse.Data = await _dataContext.Vakantie.Select(v => _mapper.Map<GetVakantieDto>(v)).ToListAsync();
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetVakantieDto>>> DeleteVakantie(int id)
        {
            ServiceResponse<List<GetVakantieDto>> serviceResponse = new ServiceResponse<List<GetVakantieDto>>();

            try
            {
                Vakantie vakantie = _dataContext.Vakantie.First(v => v.Id == id);
                _dataContext.Vakantie.Remove(vakantie);
                await _dataContext.SaveChangesAsync();

                serviceResponse.Data = await _dataContext.Vakantie.Select(v => _mapper.Map<GetVakantieDto>(v)).ToListAsync();
            }
            catch (Exception ex)
            {
                serviceResponse.Succes = false;
                serviceResponse.Message = ex.Message;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetVakantieDto>>> GetAllFromUser(int id)
        {
            var serviceResponse = new ServiceResponse<List<GetVakantieDto>>();

            List<Vakantie> vakanties = await _dataContext.Vakantie.Where(v => v.User.Id == id).ToListAsync();
            serviceResponse.Data = _mapper.Map<List<GetVakantieDto>>(vakanties);

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetVakantieDto>>> GetAllVakantie()
        {
            return new ServiceResponse<List<GetVakantieDto>> 
            { 
                Data = await _dataContext.Vakantie.Select(v => _mapper.Map<GetVakantieDto>(v)).ToListAsync()
            };
        }

        public async Task<ServiceResponse<GetVakantieDto>> GetVakantieById(int id)
        {
            var serviceResponse = new ServiceResponse<GetVakantieDto>();
            var vakantie = await _dataContext.Vakantie.FirstOrDefaultAsync(c => c.Id == id);
            serviceResponse.Data = _mapper.Map<GetVakantieDto>(vakantie);
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetVakantieDto>> UpdateKeuring(int id, UpdateKeuringVakantieDto updatedKeuring)
        {
            ServiceResponse<GetVakantieDto> serviceResponse = new ServiceResponse<GetVakantieDto>();
            
            try
            {
                Vakantie vakantie = await _dataContext.Vakantie.FirstOrDefaultAsync(v => v.Id == updatedKeuring.Id && v.Id == id);

                vakantie.GoedKeuring = updatedKeuring.GoedKeuring;

                await _dataContext.SaveChangesAsync();

                serviceResponse.Data = _mapper.Map<GetVakantieDto>(vakantie);
            }
            catch (Exception ex)
            {
                serviceResponse.Succes = false;
                serviceResponse.Message = ex.Message;
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetVakantieDto>> UpdateVakantie(int id, UpdateVakantieDto updatedVakantie)
        {
            ServiceResponse<GetVakantieDto> serviceResponse = new ServiceResponse<GetVakantieDto>();
            
            try
            {
                Vakantie vakantie = await _dataContext.Vakantie.FirstOrDefaultAsync(v => v.Id == updatedVakantie.Id && v.Id == id);

                vakantie.Naam = updatedVakantie.Naam;
                vakantie.BeginDatum = updatedVakantie.BeginDatum;
                vakantie.EindDatum = updatedVakantie.EindDatum;
                vakantie.AanvraagDatum = updatedVakantie.AanvraagDatum;

                await _dataContext.SaveChangesAsync();

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
