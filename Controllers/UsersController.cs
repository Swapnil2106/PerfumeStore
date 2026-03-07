using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PerfumeStore.DTOs.Auth;
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
    }
}
