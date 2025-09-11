using EventBoardBackend.Data.DTO;
using EventBoardBackend.Models.Entities;
using EventBoardBackend.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.StaticAssets;
using System.Security.Claims;

namespace EventBoardBackend.Controllers
{
    [Route("api/meeting")]
    [ApiController]
    public class MeetingController : ControllerBase
    {
        private MeetingService _service;
        public MeetingController(MeetingService service)
        {
            _service = service;
        }

        [HttpGet("all")]
        [Authorize(Policy = "AcceptedAccountPolicy")]
        public async Task<ActionResult<List<MeetingDto>>> GetAllMeetings()
        {
            return Ok(await _service.GetAllMeetings());
        }

        
        [HttpPost("create")]
        [Authorize(Roles = "MANAGER", Policy = "AcceptedAccountPolicy")]
        public async Task<ActionResult<List<MeetingDto>>> CreateMeeting([FromBody] MeetingDto meetingData)
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            int? managerId = null!;
            
            if (identity != null)
            {
                managerId = int.Parse(identity.FindFirst("userId").Value);
            }
            else
            {
                return Unauthorized("A manager should create meetings");
            }
            
            return Ok(await _service.CreateMeeting(meetingData, managerId.Value));
        }
    }
}
