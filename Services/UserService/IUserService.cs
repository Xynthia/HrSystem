using HRSystem.Dtos.Declaratie;
using HRSystem.Dtos.User;
using HRSystem.Dtos.Vakantie;

namespace HRSystem.Services.UserService
{
    public interface IUserService
    {
        Task<ServiceResponse<List<GetUserDto>>> getAllUsers();
        Task<ServiceResponse<GetUserDto>> getUserById(int id);
        Task<ServiceResponse<List<GetUserDto>>> AddUser(AddUserDto newUser);
        Task<ServiceResponse<GetUserDto>> UpdateUser(int id, UpdateUserDto updatedUser);
        Task<ServiceResponse<GetUserDto>> updateTeam(int id, UpdateUserDto updatedUser);
        Task<ServiceResponse<List<GetUserDto>>> DeleteUser(int id);
        Task<ServiceResponse<GetUserDto>> Login(LoginUserDto request);
        Task<ServiceResponse<List<GetDeclaratieDto>>> getDeclaraties(int id);
        Task<ServiceResponse<List<GetVakantieDto>>> getVakanties(int id);
    }
}
