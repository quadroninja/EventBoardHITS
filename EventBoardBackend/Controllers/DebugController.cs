using EventBoardBackend.Data;
using EventBoardBackend.Data.Models.Entities;
using Microsoft.AspNetCore.Mvc;

namespace EventBoardBackend.Controllers
{

    [ApiController]
    [Route("debug")]
    public class DebugController
    {
        //private readonly AppDbContext _context;

        //public DebugController(AppDbContext context)
        //{
        //    //_context = context;
        //}

        [HttpGet]
        public IActionResult CreateMeeting()
        {
            //_context.Roles.Add(new RoleModel { Name="someRole", Users=new List<UserModel>()});
            //_context.SaveChanges();
            return new NoContentResult();
        }
    }
}
