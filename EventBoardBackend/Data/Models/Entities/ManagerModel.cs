using EventBoardBackend.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace EventBoardBackend.Data.Models.Entities
{
    [Keyless]
    public class ManagerModel
    {
        [Required]
        public required UserModel User { get; set; }

        [Required] 
        public required CompanyModel Company { get; set; }
        public List<MeetingModel> ManagedMeetings { get; set; }
    }
}
