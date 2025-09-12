using EventBoardBackend.Data;
using EventBoardBackend.Data.DTO;
using EventBoardBackend.Data.Enums;
using EventBoardBackend.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace EventBoardBackend.Controllers
{
    [ApiController]
    [Route("api/admin")]
    public class AdminController : ControllerBase
    {
        private AdminService _adminService;
        public AdminController(AdminService service)
        {
            _adminService = service;
        }

        [HttpPatch("application/{userId}")]
        [Authorize(Roles = "ADMIN", Policy = "AcceptedAccountPolicy")]
        public async Task<IActionResult> ManageUserApplication(int userId, [FromQuery] UserStatus newStatus) //подтвердить или отклонить аккаунт
        {
            if (newStatus == UserStatus.REJECTED)
            {
                await _adminService.RejectUser(userId);
                return Ok();
            }
            else if (newStatus == UserStatus.ACCEPTED)
            {                
                await _adminService.AcceptUser(userId);
                return Ok();   
            }
            return Ok();
        }


        [HttpPost("company/create")]
        [Authorize(Roles = "ADMIN", Policy = "AcceptedAccountPolicy")]
        public async Task<IActionResult> CreateCompany(CompanyDto company) //подтвердить или отклонить аккаунт
        {
            await _adminService.CreateCompany(company);
            return Ok(company);
        }

    }
}
