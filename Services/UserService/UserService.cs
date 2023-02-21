using AutoMapper;
using HRSystem.Dtos.Declaratie;
using HRSystem.Dtos.User;
using HRSystem.Dtos.Vakantie;
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
            // service response die een list van getuserdto kan opslaan
            var serviceResponse = new ServiceResponse<List<GetUserDto>>();
            // map new user in user
            User user = _mapper.Map<User>(newUser);
            //add user to data context
            await _dataContext.User.AddAsync(user);
            // save changes to datacontext/db
            await _dataContext.SaveChangesAsync();

            //select all users in data context
            serviceResponse.Data = await _dataContext.User.Select(c => _mapper.Map<GetUserDto>(c)).ToListAsync();
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetUserDto>>> DeleteUser(int id)
        {
            // service response die een list van getuserdto kan opslaan
            var serviceResponse = new ServiceResponse<List<GetUserDto>>();

            try
            {
                // een user ophalen van datacontext waar id gelijk is aan gegeven id.
                User user = _dataContext.User.First(u => u.Id == id);
                // remove user van datacontext
                _dataContext.User.Remove(user);
                // save changes to datacontext/db
                await _dataContext.SaveChangesAsync();

                //select all users in data context
                serviceResponse.Data = await _dataContext.User.Select(c => _mapper.Map<GetUserDto>(c)).ToListAsync();
            }
            catch (Exception ex)
            {
                // opslaan van succes en message zodat het kan worden laten zien.
                serviceResponse.Succes = false;
                serviceResponse.Message = ex.Message;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetUserDto>>> getAllUsers()
        {
            // service response die een list van getuserdto kan opslaan
            return new ServiceResponse<List<GetUserDto>> {
                //select all users in data context
                Data = await _dataContext.User.Select(c => _mapper.Map<GetUserDto>(c)).ToListAsync()
            };
        }

        public async Task<ServiceResponse<List<GetDeclaratieDto>>> getDeclaraties(int id)
        {
            var serviceResponse = new ServiceResponse<List<GetDeclaratieDto>>();
            List<Declaratie> declaraties = await _dataContext.Declaratie.Where(d => d.User.Id == id).ToListAsync();
            serviceResponse.Data = _mapper.Map<List<GetDeclaratieDto>>(declaraties);

            return serviceResponse;
        }

        public async Task<ServiceResponse<GetUserDto>> getUserById(int id)
        {
            // service response die een getuserdto kan opslaan
            var serviceResponse = new ServiceResponse<GetUserDto>();
            var user = await _dataContext.User.FirstOrDefaultAsync(u => u.Id == id);
            //select user in data context
            serviceResponse.Data = _mapper.Map<GetUserDto>(user);

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetVakantieDto>>> getVakanties(int id)
        {
            var serviceResponse = new ServiceResponse<List<GetVakantieDto>>();
            List<Vakantie> vakanties = await _dataContext.Vakantie.Where(d => d.UserId == id).ToListAsync();
            serviceResponse.Data = _mapper.Map<List<GetVakantieDto>>(vakanties);
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetUserDto>> Login(LoginUserDto request)
        {
            // service response die een getuserdto kan opslaan
            var serviceResponse = new ServiceResponse<GetUserDto>();

            // select user waar gebruiksnaam en wachtwoord gelijk zijn aan input.
            var user = await _dataContext.User.FirstOrDefaultAsync(u => u.GebruikersNaam == request.GebruikersNaam && u.Wachtwoord == request.Wachtwoord);

            //select user in data context
            serviceResponse.Data = _mapper.Map<GetUserDto>(user);

            return serviceResponse;
        }

        public async Task<ServiceResponse<GetUserDto>> updateTeam(int id, UpdateUserDto updatedUser)
        {
            // service response die een getuserdto kan opslaan
            var serviceResponse = new ServiceResponse<GetUserDto>();

            try
            {
                //get user waar user id  gelijk is aan input.
                User user = await _dataContext.User.FirstOrDefaultAsync(u => u.Id == updatedUser.Id && u.Id == id);

                //update team.
                user.Team = updatedUser.Team;
                // save changes to datacontext/db
                await _dataContext.SaveChangesAsync();

                // map user to serviceresponse data
                serviceResponse.Data = _mapper.Map<GetUserDto>(user);
            }
            catch (Exception ex)
            {
                // opslaan van succes en message zodat het kan worden laten zien.
                serviceResponse.Succes=false;
                serviceResponse.Message=ex.Message;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<GetUserDto>> UpdateUser(int id, UpdateUserDto updatedUser)
        {
            // service response die ee getuserdto kan opslaan
            var serviceResponse = new ServiceResponse<GetUserDto>();

            try
            {
                //get user waar user id gelijk is aan input.
                User user = await _dataContext.User.FirstOrDefaultAsync(u => u.Id == updatedUser.Id && u.Id == id);

                //automatishce updates
                user = _mapper.Map<UpdateUserDto, User>(updatedUser, user);

                // save changes to datacontext/db
                await _dataContext.SaveChangesAsync();


                serviceResponse.Data = _mapper.Map<GetUserDto>(user);
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
