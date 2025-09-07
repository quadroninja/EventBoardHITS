using EventBoardBackend.Data.Models.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace EventBoardBackend.Models.Entities
{
    [Table("meetings")]
    public class MeetingModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        public DateTimeOffset MeetingDateTime { get; set; }

        public List<UserModel> Students { get; set; } //посещающие студенты
        
        public UserModel Manager { get; set; } //руководящий менеджер
        public int ManagerId { get; set; } // внешний ключ от многих событий к одному менеджеру
    }
}
