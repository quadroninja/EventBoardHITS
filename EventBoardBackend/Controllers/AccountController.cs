using Microsoft.AspNetCore.Mvc;

namespace EventBoardBackend.Controllers 
{ 
    [ApiController]
    [Route("api/account")]
    public class AccountController : ControllerBase
    {

        public AccountController()
        {
            Console.WriteLine("AccountController instantiated.");
        }

        [HttpGet]
        public ActionResult<string> GetStuff()
        {
            return Ok("Hi");
        }
    }
}
