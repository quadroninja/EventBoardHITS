namespace EventBoardBackend.Data.DTO
{
    public class MeetingDto
    {
        public string Title {  get; set; }
        public string Description { get; set; }
        public DateTimeOffset MeetingDateTime;
    }
}
