using HRSystem.Dtos.Declaratie;

namespace HRSystem.Services.DeclaratieService
{
    public interface IDeclaratieService
    {
        Task<ServiceResponse<List<GetDeclaratieDto>>> GetAll();
        Task<ServiceResponse<GetDeclaratieDto>> GetById(int id);
        Task<ServiceResponse<List<GetDeclaratieDto>>> AddDeclaratie(AddDeclaratieDto NewDeclaratie);
        Task<ServiceResponse<GetDeclaratieDto>> UpdateDeclaratie(int id, UpdateDeclaratieDto updatedDeclaratie);
        Task<ServiceResponse<List<GetDeclaratieDto>>> DeleteDeclaratie(int id);
        Task<ServiceResponse<GetDeclaratieDto>> UpdateKeuring(int id, UpdateKeuringDeclaratieDto updatedKeuring);
        Task<ServiceResponse<List<GetDeclaratieDto>>> GetAllFromUser(int id);
    }
}
