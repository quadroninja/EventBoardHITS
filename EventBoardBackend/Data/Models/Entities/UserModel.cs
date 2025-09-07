using EventBoardBackend.Models.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace EventBoardBackend.Data.Models.Entities
{
    [Table("users")]
    public class UserModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Patronymic { get; set; } //отчество - если есть

        public RoleModel Role { get; set; } //роль пользователя - Студент, Менеджер или Деканат
        public CompanyModel Company { get; set; } //только для менеджеров, для студентов - NULL
        public List<MeetingModel> AttendedMeetings { get; set; } //посещение мероприятия для студентов
        public List<MeetingModel> ManagedMeetings { get; set; } //управление мероприятия менеджером
        public List<RequestModel> Requests { get; set; } //заявки на одобрение аккаунта
                                                         //одна отправляется при регистрации, при отклонении можно подать еще
                                                         //для менеджеров может включать в себя компанию

    }
}
