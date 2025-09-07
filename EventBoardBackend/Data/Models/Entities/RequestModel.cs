using System.ComponentModel.DataAnnotations.Schema;

namespace EventBoardBackend.Data.Models.Entities
{
    [Table("requests")]
    public class RequestModel
    {
        public int Id { get; set; }
        public UserModel User { get; set; } // подающий заявку
        public CompanyModel Company { get; set; } //для менеджеров - обязательно
        public Boolean IsApproved { get; set; } // одобрена ли заявка
    }
}
