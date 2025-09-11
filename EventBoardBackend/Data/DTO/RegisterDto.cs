using EventBoardBackend.Data.Enums;
using EventBoardBackend.Data.Models.Entities;

namespace EventBoardBackend.Data.DTO
{
    public class RegisterDto
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Patronymic { get; set; }
        public UserRole Role { get; set; }
        public int CompanyId { get; set; }
    }
}
