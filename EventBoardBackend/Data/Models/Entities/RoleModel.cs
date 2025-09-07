using System.ComponentModel.DataAnnotations.Schema;

namespace EventBoardBackend.Data.Models.Entities
{
    [Table("roles")]
    public class RoleModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<UserModel> Users { get; set; } //много пользователей - одна роль
    }
}
