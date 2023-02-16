using AutoMapper;
using HRSystem.Dtos.User;
using Microsoft.EntityFrameworkCore;

namespace HRSystem.Services.UserService
{
    public class UserService : IUserService
    {
        
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
            await _dataContext.User.AddAsync(user);
            await _dataContext.SaveChangesAsync();

            serviceResponse.Data = await _dataContext.User.Select(c => _mapper.Map<GetUserDto>(c)).ToListAsync();
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetUserDto>>> DeleteUser(int id)
        {
            var serviceResponse = new ServiceResponse<List<GetUserDto>>();

            try
            {
                User user = _dataContext.User.First(u => u.Id == id);
                _dataContext.User.Remove(user);
                await _dataContext.SaveChangesAsync();

                serviceResponse.Data = await _dataContext.User.Select(c => _mapper.Map<GetUserDto>(c)).ToListAsync();
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
                Data = await _dataContext.User.Select(c => _mapper.Map<GetUserDto>(c)).ToListAsync()
            };
        }

        public async Task<ServiceResponse<GetUserDto>> getUserById(int id)
        {
            var serviceResponse = new ServiceResponse<GetUserDto>();
            var user = await _dataContext.User.FirstOrDefaultAsync(u => u.Id == id);
            serviceResponse.Data = _mapper.Map<GetUserDto>(user);
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetUserDto>> Login(LoginUserDto request)
        {
            var serviceResponse = new ServiceResponse<GetUserDto>();

            var user = await _dataContext.User.FirstOrDefaultAsync(u => u.GebruikersNaam == request.GebruikersNaam && u.Wachtwoord == request.Wachtwoord);
                
            serviceResponse.Data = _mapper.Map<GetUserDto>(user);

            return serviceResponse;
        }

        public async Task<ServiceResponse<GetUserDto>> updateTeam(int id, UpdateUserDto updatedUser)
        {
            var serviceResponse = new ServiceResponse<GetUserDto>();

            try
            {
                User user = await _dataContext.User.FirstOrDefaultAsync(u => u.Id == updatedUser.Id && u.Id == id);

                user.Team = updatedUser.Team;
                await _dataContext.SaveChangesAsync();

                serviceResponse.Data = _mapper.Map<GetUserDto>(user);
            }
            catch (Exception ex)
            {
                serviceResponse.Succes=false;
                serviceResponse.Message=ex.Message;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<GetUserDto>> UpdateUser(int id, UpdateUserDto updatedUser)
        {
            var serviceResponse = new ServiceResponse<GetUserDto>();

            try
            {

                User user = await _dataContext.User.FirstOrDefaultAsync(u => u.Id == updatedUser.Id && u.Id == id);

                //handmatig updates
                user.GebruikersNaam = updatedUser.GebruikersNaam;
                user.VoorNaam = updatedUser.VoorNaam;
                user.AchterNaam = updatedUser.AchterNaam;
                user.Wachtwoord = updatedUser.Wachtwoord;
                user.Email = updatedUser.Email;
                user.Team = updatedUser.Team;
                user.Rol = updatedUser.Rol;

                await _dataContext.SaveChangesAsync();

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
