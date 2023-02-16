using HRSystem.Services.UserService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using HRSystem.Dtos.User;

namespace HRSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        public IUserService _userService { get; }

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<GetUserDto>>> Get()
        {
            return Ok(await _userService.getAllUsers());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<GetUserDto>>> GetSingleUser(int id)
        {
            return Ok(await _userService.getUserById(id));
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<GetUserDto>>> AddUser(AddUserDto newUser)
        {
            return Ok(await _userService.AddUser(newUser));
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ServiceResponse<List<GetUserDto>>>> UpdateUser(int id, UpdateUserDto updatedUser)
        {
            var serviceResponse = await _userService.UpdateUser(id, updatedUser);
            if(serviceResponse.Data == null)
            {
                return NotFound(serviceResponse);
            }
            return Ok(serviceResponse);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ServiceResponse<List<GetUserDto>>>> DeleteUser(int id)
        {
            var serviceResponse = await _userService.DeleteUser(id);
            if (serviceResponse.Data == null)
            {
                return NotFound(serviceResponse);
            }
            return Ok(serviceResponse);
        }


        [HttpPut("{id}/Team")]
        public async Task<ActionResult<ServiceResponse<List<GetUserDto>>>> UpdateTeam(int id, UpdateUserDto updatedTeam)
        {
            var serviceResponse = await _userService.updateTeam(id, updatedTeam);
            if(serviceResponse.Data == null)
            {
                return NotFound(serviceResponse);
            }
            return Ok(serviceResponse);
        }


        [HttpPost("Login")]
        public async Task<ActionResult<ServiceResponse<GetUserDto>>> Login(LoginUserDto request)
        {
            var serviceResponse = await _userService.Login(request);
            if(serviceResponse.Data == null)
            {
                return NotFound(serviceResponse);
            }
            return Ok(serviceResponse);
        }
    }
}
