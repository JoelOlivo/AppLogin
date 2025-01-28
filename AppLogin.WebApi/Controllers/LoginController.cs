using AppLogin.WebApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AppLogin.Application.UserLogin;

namespace AppLogin.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly UserLogin _userLogin;

        //Inyectar caso de uso
        public LoginController(UserLogin userLogin)
        {
            _userLogin = userLogin;
        }

        [HttpPost]
        public async Task<IActionResult> Login([FromBody] LoginDto loginDto)
        {
            try
            {
                var token = await _userLogin.Execute(loginDto.Email, loginDto.Password);
                return Ok(new { token });
            }
            catch (UnauthorizedAccessException ex)
            {
                return Unauthorized(ex.Message);
            }
        }
    }
}
