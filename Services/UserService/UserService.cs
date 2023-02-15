using AutoMapper;
using HRSystem.Dtos.User;
using Microsoft.EntityFrameworkCore;

namespace HRSystem.Services.UserService
{
    public class UserService : IUserService
    {
        private static List<User> users = new List<User>
        {
            new User(),
            new User{ Id = 1, VoorNaam = "Jack", GebruikersNaam = "JackBlack"},
        };

        private readonly IMapper _mapper;
        private readonly DataContext _dataContext;

        public UserService(DataContext dataContext, IMapper mapper)
        {
            _mapper = mapper;
            _dataContext = dataContext;
        }

        public async Task<ServiceResponse<List<GetUserDto>>> AddUser(AddUserDto newUser)
        {
            var serviceResponse = new ServiceResponse<List<GetUserDto>>();
            User user = _mapper.Map<User>(newUser);
            _dataContext.Users.Add(user);
            _dataContext.SaveChanges();

            serviceResponse.Data = _dataContext.Users.Select(c => _mapper.Map<GetUserDto>(c)).ToList();
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetUserDto>>> DeleteUser(int id)
        {
            ServiceResponse<List<GetUserDto>> serviceResponse = new ServiceResponse<List<GetUserDto>>();

            try
            {
                User user = _dataContext.Users.First(u => u.Id == id);
                _dataContext.Users.Remove(user);
                _dataContext.SaveChanges();

                serviceResponse.Data = _dataContext.Users.Select(c => _mapper.Map<GetUserDto>(c)).ToList();
            }
            catch (Exception ex)
            {
                serviceResponse.Succes = false;
                serviceResponse.Message = ex.Message;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetUserDto>>> getAllUsers()
        {
            return new ServiceResponse<List<GetUserDto>> {
                Data = _dataContext.Users.Select(c => _mapper.Map<GetUserDto>(c)).ToList()
            };
        }

        public async Task<ServiceResponse<GetUserDto>> getUserById(int id)
        {
            var serviceResponse = new ServiceResponse<GetUserDto>();
            var user = _dataContext.Users.FirstOrDefault(u => u.Id == id);
            serviceResponse.Data = _mapper.Map<GetUserDto>(user);
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetUserDto>> Login(LoginUserDto request)
        {
            var serviceResponse = new ServiceResponse<GetUserDto>();

            var user = _dataContext.Users.FirstOrDefault(u => u.GebruikersNaam == request.GebruikersNaam && u.Wachtwoord == request.Wachtwoord);
                
            serviceResponse.Data = _mapper.Map<GetUserDto>(user);

            return serviceResponse;
        }

        public async Task<ServiceResponse<GetUserDto>> updateTeam(UpdateUserDto updatedUser)
        {
            ServiceResponse<GetUserDto> serviceResponse = new ServiceResponse<GetUserDto>();

            try
            {
                User user = _dataContext.Users.FirstOrDefault(u => u.Id == updatedUser.Id);

                user.Team = updatedUser.Team;
                _dataContext.SaveChanges();

                serviceResponse.Data = _mapper.Map<GetUserDto>(user);
            }
            catch (Exception ex)
            {
                serviceResponse.Succes=false;
                serviceResponse.Message=ex.Message;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<GetUserDto>> UpdateUser(UpdateUserDto updatedUser)
        {
            ServiceResponse<GetUserDto> serviceResponse = new ServiceResponse<GetUserDto>();

            try
            {

                User user = _dataContext.Users.FirstOrDefault(u => u.Id == updatedUser.Id);

                //handmatig updates
                user.GebruikersNaam = updatedUser.GebruikersNaam;
                user.VoorNaam = updatedUser.VoorNaam;
                user.AchterNaam = updatedUser.AchterNaam;
                user.Wachtwoord = updatedUser.Wachtwoord;
                user.Email = updatedUser.Email;
                user.Team = updatedUser.Team;
                user.Rol = updatedUser.Rol;
                /*user.Vakantie = updatedUser.Vakantie;
                user.Declaratie = updatedUser.Declaratie;*/

                _dataContext.SaveChanges();

                //automatic updates
                /*_mapper.Map(updatedUser, user);*/

                serviceResponse.Data = _mapper.Map<GetUserDto>(user);
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
