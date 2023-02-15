using AutoMapper;
using HRSystem.Dtos.Declaratie;

namespace HRSystem.Services.DeclaratieService
{
    public class DeclaratieService : IDeclaratieService
    {
        private static List<Declaratie> declaraties = new List<Declaratie>
        {
            new Declaratie(),
            new Declaratie{ Id = 1, Naam = "jan Declaratie" }
        };
        private readonly IMapper _mapper;

        public DeclaratieService(IMapper mapper)
        {
            _mapper = mapper;
        }

        public async Task<ServiceResponse<List<GetDeclaratieDto>>> AddDeclaratie(AddDeclaratieDto newDeclaratie)
        {
            var serviceResponse = new ServiceResponse<List<GetDeclaratieDto>>();
            Declaratie declaratie = _mapper.Map<Declaratie>(newDeclaratie);
            declaratie.Id = declaraties.Max(d => d.Id) + 1;
            declaraties.Add(declaratie);
            serviceResponse.Data = declaraties.Select(d => _mapper.Map<GetDeclaratieDto>(d)).ToList();
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetDeclaratieDto>>> DeleteDeclaratie(int id)
        {
            ServiceResponse<List<GetDeclaratieDto>> serviceResponse = new ServiceResponse<List<GetDeclaratieDto>>();

            try
            {
                Declaratie declaratie = declaraties.First(d => d.Id == id);
                declaraties.Remove(declaratie);


                serviceResponse.Data = declaraties.Select(d => _mapper.Map<GetDeclaratieDto>(d)).ToList();
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
                Data = declaraties.Select(d => _mapper.Map<GetDeclaratieDto>(d)).ToList()
            };
        }

        public async Task<ServiceResponse<GetDeclaratieDto>> GetById(int id)
        {
            var serviceResponse = new ServiceResponse<GetDeclaratieDto>();
            Declaratie declaratie = declaraties.FirstOrDefault(d => d.Id == id);
            serviceResponse.Data = _mapper.Map<GetDeclaratieDto>(declaratie);
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetDeclaratieDto>> UpdateDeclaratie(UpdateDeclaratieDto updatedDeclaratie)
        {
            ServiceResponse<GetDeclaratieDto> serviceResponse = new ServiceResponse<GetDeclaratieDto>();

            try
            {
                Declaratie declaratie = declaraties.FirstOrDefault(d => d.Id == updatedDeclaratie.Id);

                declaratie.Naam = updatedDeclaratie.Naam;
                declaratie.AanvraagDatum = updatedDeclaratie.AanvraagDatum;
                declaratie.Omschrijving = updatedDeclaratie.Omschrijving;
                declaratie.Documenten = updatedDeclaratie.Documenten;
                declaratie.GoedKeuring = updatedDeclaratie.GoedKeuring;
                declaratie.Bedrag = updatedDeclaratie.Bedrag;
                declaratie.Btw = updatedDeclaratie.Btw;
                declaratie.Categorie = updatedDeclaratie.Categorie;

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
                Declaratie declaratie = declaraties.FirstOrDefault(d => d.Id == updatedDeclaratie.Id);

                declaratie.GoedKeuring = updatedDeclaratie.GoedKeuring;

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
