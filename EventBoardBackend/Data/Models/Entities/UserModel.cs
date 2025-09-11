using EventBoardBackend.Data.Enums;
using EventBoardBackend.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EventBoardBackend.Data.Models.Entities
{
    public class UserModel
    {
        public int Id { get; set; }
        
        [Required]
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Patronymic { get; set; } //отчество - если есть
        

        public int? CompanyId { get; set; }
        public string RejectionReason { get; set; } //NULL до обработки заявки и после одобрения, имеет значение если заявка отклонена

        [Required]
        public string Email { get; set; }
        [Required]
        public string HashedPassword { get; set; }

        public ManagerModel Manager { get; set; }
        public StudentModel Student { get; set; }

        [Required]
        public UserRole Role { get; set; } //роль пользователя - STUDENT, MANAGER, ADMIN
        [Required]
        public UserStatus Status { get; set; } //пользователь может быть PENDING, ACCEPTED, REJECTED
        
    }
}
