using EventBoardBackend.Data;
using EventBoardBackend.Data.Models.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

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

        [HttpGet("admin")]
        [Authorize(Roles = "ADMIN")]
        public IActionResult Admin()
        {
            return new NoContentResult();
        }
        [HttpGet("manager")]
        [Authorize(Roles = "MANAGER")]
        public IActionResult Manager()
        {
            return new NoContentResult();
        }
        [HttpGet("student")]
        [Authorize(Roles = "STUDENT")]
        public IActionResult Student()
        {
            return new NoContentResult();
        }

        [HttpGet("admin_or_manager")]
        [Authorize(Roles = "ADMIN,MANAGER")]
        public IActionResult AdminManager()
        {
            return new NoContentResult();
        }

        //[HttpGet("show_roles")]
        //public IActionResult ShowRoles()
        //{
        //    // Get all roles from claims
        //    var roles = HttpContext.User .Claims
        //        .Where(c => c.Type == ClaimTypes.Role || c.Type == "role")
        //        .Select(c => c.Value)
        //        .ToList();
        //    // Just return roles for demonstration
        //    return Ok(new { Roles = roles });
        //}

    }
}
