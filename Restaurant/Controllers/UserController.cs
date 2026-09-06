using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using Restaurant.DTOs;
using Restaurant.Services.Interfaces;

namespace Restaurant.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userservice;
        public UserController(IUserService userservice)
        {
            _userservice = userservice;
        }

        [HttpPost("register")]

        public async Task<IActionResult> Register(RegisterUserRequest request)
        {
            var result = await _userservice.RegisterUserAsync(request);

            return Ok(result);

        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginUserRequest request)
        {
            var result = await _userservice.LoginUserAsync(request);

            return Ok(result);
        }

    }
}
