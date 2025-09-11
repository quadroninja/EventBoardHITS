using EventBoardBackend.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EventBoardBackend.Data.Models.Entities
{
    [Keyless]
    public class StudentModel
    {
        [Required]
        public required UserModel User { get; set; }
        public List<MeetingModel> AttendedMeetings { get; set; }
    }
}
