using EventBoardBackend.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EventBoardBackend.Data.Models.Entities
{
    public class StudentModel
    {
        public int Id { get; set; }
        public UserModel User { get; set; }
        public List<MeetingModel> AttendedMeetings { get; set; } = new List<MeetingModel>();
    }
}
