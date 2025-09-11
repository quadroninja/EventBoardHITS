using EventBoardBackend.Data.DTO;
using EventBoardBackend.Services.Auth;
using Microsoft.AspNetCore.Mvc;

namespace EventBoardBackend.Controllers 
{ 
    [ApiController]
    [Route("api/account")]
    public class AccountController : ControllerBase
    {
        private PasswordHasher _passwordHasher;

        public AccountController(PasswordHasher hasher)
        {
            _passwordHasher = hasher;
        }
        
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterDto registerDto)
        {
            string passwordHashed = _passwordHasher.Generate(registerDto.Password);
            
            return Ok(registerDto);
        }

    }
}
