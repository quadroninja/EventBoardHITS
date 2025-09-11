using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EventBoardBackend.Data.Models.Entities
{
    public class CompanyModel
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public List<ManagerModel> Managers { get; set; } 
    }
}
