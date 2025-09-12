using EventBoardBackend.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EventBoardBackend.Data.Models.Entities
{
    public class ManagerModel
    {
        public int Id { get; set; } 

        [Required]
        public UserModel User { get; set; }


        [Required]
        public int CompanyId;
        [Required]
        public CompanyModel Company { get; set; }
        public List<MeetingModel> ManagedMeetings { get; set; }
    }
}
