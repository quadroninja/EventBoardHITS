using EventBoardBackend.Data.Enums;
using EventBoardBackend.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EventBoardBackend.Data.Models.Entities
{

    [Index(nameof(Email), IsUnique = true)]
    public class UserModel
    {
        public int Id { get; set; }
        
        [Required]
        public required string Name { get; set; }
        public string? Surname { get; set; }
        public string? Patronymic { get; set; } //отчество - если есть
        

        public int? CompanyId { get; set; }

        [Required]
        public required string Email { get; set; }
        [Required]
        public required string HashedPassword { get; set; }

        public List<ManagerModel> Managers { get; set; }
        public List<StudentModel> Students { get; set; }

        [Required]
        public required UserRole Role { get; set; } //роль пользователя - STUDENT, MANAGER, ADMIN

        [Required]
        public required UserStatus Status { get; set; } //пользователь может быть PENDING, ACCEPTED, REJECTED
        
        public string? RejectionReason; //NULL до обработки заявки и после одобрения, имеет значение если заявка отклонена
    }
}
