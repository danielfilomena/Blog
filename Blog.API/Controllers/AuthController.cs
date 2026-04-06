using Blog.Application.Dtos;
using Blog.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Blog.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {

        private readonly IAuthService _service;

        public AuthController(IAuthService service)
        {
            _service = service;
        }

        [AllowAnonymous]
        [HttpPost("registerUser")]
        public async Task<IActionResult> Register([FromBody] UserDto user)
        {
            await _service.RegisterUser(user);
            return Ok();
            
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] UserDto user)
        {

            var token = await _service.Login(user);
            return Ok(token);

        }

    }
}
