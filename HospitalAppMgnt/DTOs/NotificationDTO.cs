namespace HospitalAppMgnt.DTOs
{
    public class NotificationDTO
    {
        public int NotificationId { get; set; }
        public int UserId { get; set; }
        public string Message { get; set; }
        public DateTime Timestamp {  get; set; }
        public string Status { get; set; }


    }
}
