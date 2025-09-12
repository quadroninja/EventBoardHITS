using EventBoardBackend.Data.DTO;
using EventBoardBackend.Services;
using EventBoardBackend.Services.Auth;
using Microsoft.AspNetCore.Mvc;

namespace EventBoardBackend.Controllers 
{ 
    [ApiController]
    [Route("api/account")]
    public class AccountController : ControllerBase
    {
        private PasswordHasher _passwordHasher;
        private AccountService _accountService;

        public AccountController(PasswordHasher hasher, AccountService accountService)
        {
            _passwordHasher = hasher;
            _accountService = accountService;
        }
        
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterDto registerDto)
        {
            string passwordHashed = _passwordHasher.Generate(registerDto.Password);

            _accountService.Register(registerDto);

            return Ok(registerDto);
        }

        [HttpPost("login")]
        public async Task<ActionResult<string>> Login([FromBody] LoginDto loginDto)
        {
            string passwordHashed = _passwordHasher.Generate(loginDto.Password);

            string token = await _accountService.Login(loginDto);

            HttpContext.Response.Cookies.Append("token-cookie", token);

            return Ok(token);
        }

    }
}
