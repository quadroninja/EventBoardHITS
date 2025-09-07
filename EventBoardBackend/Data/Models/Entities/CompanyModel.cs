using System.ComponentModel.DataAnnotations.Schema;

namespace EventBoardBackend.Data.Models.Entities
{
    [Table("companies")]
    public class CompanyModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<UserModel> Managers { get; set; } 
        public List<RequestModel> Requests { get; set; } // заявки на вступление в компанию
    }
}
