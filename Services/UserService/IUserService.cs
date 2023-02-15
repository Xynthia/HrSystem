using HRSystem.Dtos.User;

namespace HRSystem.Services.UserService
{
    public interface IUserService
    {
        Task<ServiceResponse<List<GetUserDto>>> getAllUsers();
        Task<ServiceResponse<GetUserDto>> getUserById(int id);
        Task<ServiceResponse<List<GetUserDto>>> AddUser(AddUserDto newUser);
        Task<ServiceResponse<GetUserDto>> UpdateUser(UpdateUserDto updatedUser);
        Task<ServiceResponse<GetUserDto>> updateTeam(UpdateUserDto updatedUser);
        Task<ServiceResponse<List<GetUserDto>>> DeleteUser(int id);
        Task<ServiceResponse<GetUserDto>> Login(LoginUserDto request);
    }
}
