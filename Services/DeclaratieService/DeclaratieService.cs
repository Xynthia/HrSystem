using AutoMapper;
using HRSystem.Dtos.Declaratie;

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
            var serviceResponse = new ServiceResponse<List<GetDeclaratieDto>>();
            Declaratie declaratie = _mapper.Map<Declaratie>(newDeclaratie);
            _dataContext.Declaratie.Add(declaratie);
            _dataContext.SaveChanges();
            serviceResponse.Data = _dataContext.Declaratie.Select(d => _mapper.Map<GetDeclaratieDto>(d)).ToList();
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetDeclaratieDto>>> DeleteDeclaratie(int id)
        {
            ServiceResponse<List<GetDeclaratieDto>> serviceResponse = new ServiceResponse<List<GetDeclaratieDto>>();

            try
            {
                Declaratie declaratie = _dataContext.Declaratie.First(d => d.Id == id);
                _dataContext.Declaratie.Remove(declaratie);
                _dataContext.SaveChanges();

                serviceResponse.Data = _dataContext.Declaratie.Select(d => _mapper.Map<GetDeclaratieDto>(d)).ToList();
            }
            catch (Exception ex)
            {
                serviceResponse.Succes = false;
                serviceResponse.Message = ex.Message;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetDeclaratieDto>>> GetAll()
        {
            return new ServiceResponse<List<GetDeclaratieDto>>
            {
                Data = _dataContext.Declaratie.Select(d => _mapper.Map<GetDeclaratieDto>(d)).ToList()
            };
        }

        public async Task<ServiceResponse<GetDeclaratieDto>> GetById(int id)
        {
            var serviceResponse = new ServiceResponse<GetDeclaratieDto>();
            Declaratie declaratie = _dataContext.Declaratie.FirstOrDefault(d => d.Id == id);
            serviceResponse.Data = _mapper.Map<GetDeclaratieDto>(declaratie);
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetDeclaratieDto>> UpdateDeclaratie(UpdateDeclaratieDto updatedDeclaratie)
        {
            ServiceResponse<GetDeclaratieDto> serviceResponse = new ServiceResponse<GetDeclaratieDto>();

            try
            {
                Declaratie declaratie = _dataContext.Declaratie.FirstOrDefault(d => d.Id == updatedDeclaratie.Id);

                declaratie.Naam = updatedDeclaratie.Naam;
                declaratie.AanvraagDatum = updatedDeclaratie.AanvraagDatum;
                declaratie.Omschrijving = updatedDeclaratie.Omschrijving;
                declaratie.Documenten = updatedDeclaratie.Documenten;
                declaratie.GoedKeuring = updatedDeclaratie.GoedKeuring;
                declaratie.Bedrag = updatedDeclaratie.Bedrag;
                declaratie.Btw = updatedDeclaratie.Btw;
                declaratie.Categorie = updatedDeclaratie.Categorie;

                _dataContext.SaveChanges();

                serviceResponse.Data = _mapper.Map<GetDeclaratieDto>(declaratie);
            }
            catch (Exception ex)
            {
                serviceResponse.Succes = false;
                serviceResponse.Message = ex.Message;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<GetDeclaratieDto>> UpdateGoedKeuring(UpdateDeclaratieDto updatedDeclaratie)
        {
            ServiceResponse<GetDeclaratieDto> serviceResponse = new ServiceResponse<GetDeclaratieDto>();

            try
            {
                Declaratie declaratie = _dataContext.Declaratie.FirstOrDefault(d => d.Id == updatedDeclaratie.Id);

                declaratie.GoedKeuring = updatedDeclaratie.GoedKeuring;

                _dataContext.SaveChanges();

                serviceResponse.Data = _mapper.Map<GetDeclaratieDto>(declaratie);
            }
            catch(Exception ex)
            {
                serviceResponse.Succes = false;
                serviceResponse.Message = ex.Message;
            }

            return serviceResponse;
        }
    }
}
