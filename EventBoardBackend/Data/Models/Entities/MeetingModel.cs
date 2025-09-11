using EventBoardBackend.Data.Models.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EventBoardBackend.Models.Entities
{
    public class MeetingModel
    {

        public int Id { get; set; }

        [Required]
        public required string Title { get; set; }
        public string? Description { get; set; }

        [Required]
        public required DateTimeOffset MeetingDateTime { get; set; }

        public List<StudentModel> Students { get; set; } //посещающие студенты
        
        public required ManagerModel Manager { get; set; } //руководящий менеджер
    }
}
