using Microsoft.AspNetCore.Mvc;
using MyApp.IServices;
using static MyApp.Dto.UserDto;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MyApp.API.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService ?? throw new ArgumentNullException(nameof(userService));
        }


        // GET: api/<UserController>
        [HttpGet]
        public async Task<IEnumerable<GetUserDto>> Get()
        {
            return await _userService.GetAllUserAsync();
        }

        // GET api/<UserController>/5
        [HttpGet("{id}")]
        public async Task<GetUserDto> Get(Guid id)
        {
            return await _userService.GetUserByIdAsync(id);
        }

        // POST api/<UserController>
        [HttpPost]
        public async Task<GetUserDto> Post([FromBody] CreateUserDto userDto)
        {
            return await _userService.CreateUserAsync(userDto);
        }

        // PUT api/<UserController>/5
        [HttpPut("{id}")]
        public async Task<GetUserDto> Put(Guid id, [FromBody] UpdateUserDto userDto)
        {
            return await _userService.UpdateUserByIdAsync(id, userDto);
        }

        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public async Task<bool> Delete(Guid id)
        {
            return await _userService.DeleteUserByIdAsync(id);
        }
    }
}
