using AutoMapper;
using HRSystem.Dtos.Declaratie;
using Microsoft.EntityFrameworkCore;

namespace HRSystem.Services.DeclaratieService
{
    public class DeclaratieService : IDeclaratieService
    {
       
        private readonly DataContext _dataContext;
        private readonly IMapper _mapper;

        public DeclaratieService(DataContext dataContext, IMapper mapper)
        {
            _dataContext = dataContext;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<List<GetDeclaratieDto>>> AddDeclaratie(AddDeclaratieDto newDeclaratie)
        {
            // een nieuwe serviceresponse waarin een lijst van declaratie kan worden opgeslagen
            var serviceResponse = new ServiceResponse<List<GetDeclaratieDto>>();
            // nieuwe declaratie van
            Declaratie declaratie = _mapper.Map<Declaratie>(newDeclaratie);
            //toevoegen van declaratie bij database
            await _dataContext.Declaratie.AddAsync(declaratie);
            //opslaan van verandering aan database
            await _dataContext.SaveChangesAsync();

            //data van select toevoegen aan serviceresponse zodat je data van alle declaraties in de lijst kan zien 
            serviceResponse.Data = await _dataContext.Declaratie.Select(d => _mapper.Map<GetDeclaratieDto>(d)).ToListAsync();
            //return van serviceresponse
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetDeclaratieDto>>> DeleteDeclaratie(int id)
        {
            var serviceResponse = new ServiceResponse<List<GetDeclaratieDto>>();

            try
            {
                // zoek de eerste declaratie die een Id heeft gelijk aan de meegegeven id.
                Declaratie declaratie = await _dataContext.Declaratie.FirstAsync(d => d.Id == id);
                //remove declaratie van table
                _dataContext.Declaratie.Remove(declaratie);
                // het opslaan van de veranderingen 
                await _dataContext.SaveChangesAsync();

                //data van select toevoegen aan serviceresponse zodat je data van alle declaraties in de lijst kan zien 
                serviceResponse.Data = await _dataContext.Declaratie.Select(d => _mapper.Map<GetDeclaratieDto>(d)).ToListAsync();
            }
            catch (Exception ex)
            {
                // opslaan van succes en message zodat het kan worden laten zien.
                serviceResponse.Succes = false;
                serviceResponse.Message = ex.Message;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetDeclaratieDto>>> GetAll()
        {
            //een list data van select toevoegen aan serviceresponse zodat je data van alle declaraties in de lijst kan zien 
            return new ServiceResponse<List<GetDeclaratieDto>>
            {
                Data = await _dataContext.Declaratie.Select(d => _mapper.Map<GetDeclaratieDto>(d)).ToListAsync()
            };
        }

        public async Task<ServiceResponse<List<GetDeclaratieDto>>> GetAllGoedKeuring()
        {
            // new list serviceResponse van getDeclaratieDto zodat je de declaratie van een bepaalde user in een lisjt kan zien.
            var serviceResponse = new ServiceResponse<List<GetDeclaratieDto>>();
            // een lijst van declaraties waar de keuring gelijk is aan true
            List<Declaratie> declaraties = await _dataContext.Declaratie.Where(d => d.Keuring == true).ToListAsync();
            // de lijst in service response data zetten.
            serviceResponse.Data = _mapper.Map<List<GetDeclaratieDto>>(declaraties);

            return serviceResponse;
        }

        public async Task<ServiceResponse<GetDeclaratieDto>> GetById(int id)
        {
            // new serviceResponse van GetDeclaratieDto
            var serviceResponse = new ServiceResponse<GetDeclaratieDto>();
            // get declaratie waar declaratie id gelijk is aan input id
            Declaratie declaratie = await _dataContext.Declaratie.FirstOrDefaultAsync(d => d.Id == id);
            //declaratie in serviceresponse data zetten.
            serviceResponse.Data = _mapper.Map<GetDeclaratieDto>(declaratie);
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetDeclaratieDto>> UpdateDeclaratie(int id, UpdateDeclaratieDto updatedDeclaratie)
        {
            // new serviceResponse van GetDeclaratie
            var serviceResponse = new ServiceResponse<GetDeclaratieDto>();

            try
            {
                //  get declaratie waar waar id gelijk is aan updatedDeclaratie id
                Declaratie declaratie = await _dataContext.Declaratie.FirstOrDefaultAsync(d => d.Id == updatedDeclaratie.Id && d.Id == id);

                // update data
                declaratie = _mapper.Map<UpdateDeclaratieDto, Declaratie>(updatedDeclaratie, declaratie);

                //save changes to database
                await _dataContext.SaveChangesAsync();

                //settign service response data met declaratie data
                serviceResponse.Data = _mapper.Map<GetDeclaratieDto>(declaratie);
            }
            catch (Exception ex)
            {
                // als iets mis gaat succes failed en extar message voor duidelijkheid van error
                serviceResponse.Succes = false;
                serviceResponse.Message = ex.Message;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<GetDeclaratieDto>> UpdateKeuring(int id, bool keuring)
        {
            // serviceResponse van getDeclaratie
            var serviceResponse = new ServiceResponse<GetDeclaratieDto>();

            try
            {
                //  get declaratie waar waar id gelijk is aan updatedDeclaratie id
                Declaratie declaratie = await _dataContext.Declaratie.FirstOrDefaultAsync(d => d.Id == id);

                //update goekeuring
                declaratie.Keuring = keuring;

                //savechanges to database
                await _dataContext.SaveChangesAsync();

                // serviceresoonse data heeft declaratie data
                serviceResponse.Data = _mapper.Map<GetDeclaratieDto>(declaratie);
            }
            catch(Exception ex)
            {
                // als iets mis gaat succes failed en extar message voor duidelijkheid van error
                serviceResponse.Succes = false;
                serviceResponse.Message = ex.Message;
            }

            return serviceResponse;
        }
    }
}
