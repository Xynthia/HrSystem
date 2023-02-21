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
            // service response die een list van getuserdto kan opslaan
            var serviceResponse = new ServiceResponse<List<GetVakantieDto>>();
            // map new vakantie in vakantie
            Vakantie vakantie = _mapper.Map<Vakantie>(newVakantie);
            // vakantie toevoegen aan data context
            await _dataContext.AddAsync(vakantie);
            // save changes datacontext
            await _dataContext.SaveChangesAsync();

            //select all vakanties en set ze in data
            serviceResponse.Data = await _dataContext.Vakantie.Select(v => _mapper.Map<GetVakantieDto>(v)).ToListAsync();
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetVakantieDto>>> DeleteVakantie(int id)
        {
            // service response die een list van getuserdto kan opslaan
            var serviceResponse = new ServiceResponse<List<GetVakantieDto>>();

            try
            {
                // get vakantie waar id gelijk is aan input id
                Vakantie vakantie = _dataContext.Vakantie.First(v => v.Id == id);
                // verwijder vakantie van datacontext
                _dataContext.Vakantie.Remove(vakantie);
                //SaveChanges changes in datacontext
                await _dataContext.SaveChangesAsync();

                // select all vakanties en set ze in serviceresponse data
                serviceResponse.Data = await _dataContext.Vakantie.Select(v => _mapper.Map<GetVakantieDto>(v)).ToListAsync();
            }
            catch (Exception ex)
            {
                // opslaan van succes en message zodat het kan worden laten zien.
                serviceResponse.Succes = false;
                serviceResponse.Message = ex.Message;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetVakantieDto>>> GetAllGoedKeuring()
        {
            // service response die een list van getuserdto kan opslaan
            var serviceResponse = new ServiceResponse<List<GetVakantieDto>>();
            //get vakantie waar keuring true(goed) is.
            List<Vakantie> vakanties = await _dataContext.Vakantie.Where(v => v.Keuring == true).ToListAsync();
            //set vakanties in data
            serviceResponse.Data = _mapper.Map<List<GetVakantieDto>>(vakanties);

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetVakantieDto>>> GetAllVakantie()
        {
            // service response die een List van getuserdto kan opslaan
            return new ServiceResponse<List<GetVakantieDto>> 
            { 
                // get all vakanties
                Data = await _dataContext.Vakantie.Select(v => _mapper.Map<GetVakantieDto>(v)).ToListAsync()
            };
        }

        public async Task<ServiceResponse<GetVakantieDto>> GetVakantieById(int id)
        {
            // service response die een getuserdto kan opslaan
            var serviceResponse = new ServiceResponse<GetVakantieDto>();
            // get vakantie waar id gelijk is aan input id.
            var vakantie = await _dataContext.Vakantie.FirstOrDefaultAsync(c => c.Id == id);
            // map vakantie in data
            serviceResponse.Data = _mapper.Map<GetVakantieDto>(vakantie);
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetVakantieDto>> UpdateKeuring(int id, UpdateKeuringVakantieDto updatedKeuring, bool keuring)
        {
            // service response die een getuserdto kan opslaan
            var serviceResponse = new ServiceResponse<GetVakantieDto>();
            
            try
            {
                // get vakantie waar id gelijk moet zijn aan input id.
                Vakantie vakantie = await _dataContext.Vakantie.FirstOrDefaultAsync(v => v.Id == updatedKeuring.Id && v.Id == id);

                // update keruing
                vakantie.Keuring = keuring;

                // save changes to datacontext
                await _dataContext.SaveChangesAsync();

                //map vakantie naar data
                serviceResponse.Data = _mapper.Map<GetVakantieDto>(vakantie);
            }
            catch (Exception ex)
            {
                // opslaan van succes en message zodat het kan worden laten zien.
                serviceResponse.Succes = false;
                serviceResponse.Message = ex.Message;
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetVakantieDto>> UpdateVakantie(int id, UpdateVakantieDto updatedVakantie)
        {
            // service response die een getuserdto kan opslaan
            var serviceResponse = new ServiceResponse<GetVakantieDto>();
            
            try
            {
                // get vakantie waar id gelijk moet zijn aan input id.
                Vakantie vakantie = await _dataContext.Vakantie.FirstOrDefaultAsync(v => v.Id == updatedVakantie.Id && v.Id == id);

                //update data
                vakantie.Naam = updatedVakantie.Naam;
                vakantie.BeginDatum = updatedVakantie.BeginDatum;
                vakantie.EindDatum = updatedVakantie.EindDatum;
                vakantie.AanvraagDatum = updatedVakantie.AanvraagDatum;

                // dsave change to datacontext.
                await _dataContext.SaveChangesAsync();

                //map vakantie in data
                serviceResponse.Data = _mapper.Map<GetVakantieDto>(vakantie);
            }
            catch (Exception ex)
            {
                // opslaan van succes en message zodat het kan worden laten zien.
                serviceResponse.Succes = false;
                serviceResponse.Message = ex.Message;
            }

            return serviceResponse;
        }

        
    }
}
