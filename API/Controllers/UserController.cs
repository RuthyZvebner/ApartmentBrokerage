using Core.Dtos;
using Core.Entities;
using Core.IServices;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        // GET: api/<UserController>
        [HttpGet]
        public async Task<IEnumerable<UserDto>> GetAsync()
        {
            return await _userService.GetAsync();
        }

        // GET api/<UserController>/5
        [HttpGet("{id}")]
        public async Task<UserDto> GetByIdAsync(Guid id)
        {
            return await _userService.GetByIdAsync(id);
        }

        // POST api/<UserController>
        [HttpPost]
        public async Task<UserDto> PostAsync([FromBody] UserDto user)
        {
            return await _userService.PostAsync(user);
        }

        // PUT api/<UserController>/5
        [HttpPut("{id}")]
        public async Task<UserDto> PutAsync(Guid id, [FromBody] UserDto user)
        {
            return await _userService.PutAsync(id, user);
        }

        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public async Task<User> DeleteAsync(Guid id)
        {
            return await _userService.DeleteAsync(id);
        }
    }
}
