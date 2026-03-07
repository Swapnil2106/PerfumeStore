using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PerfumeStore.DTOs.Auth;
using PerfumeStore.DTOs.User;
using PerfumeStore.Services;

namespace PerfumeStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly UserService userService;

        public UsersController(UserService _userService)
        {
            userService = _userService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> RegisterUser(RegisterUserDTO dto)
        {
            var createdUser = await userService.RegisterUser(dto);

            return Ok(createdUser);
        }

        [HttpPost("login")]
        public async Task<IActionResult> LoginUser(LoginUserDTO dto)
        {
            var token = await userService.LoginUser(dto);

            return Ok(new
            {
                Token = token
            });
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(int id, UpdateUserDTO dto)
        {
            var updatedUser = await userService.UpdateUser(id, dto);

            return Ok(updatedUser);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await userService.DeleteUser(id);

            return NoContent(); //204
        }
    }
}
