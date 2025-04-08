namespace HospitalAppMgnt.DTOs
{
    public class DoctorScheduleDTO
    {
        public int ScheduleId { get; set; }
        public int DoctorId { get; set; }
        public string AvailableTimeSlots { get; set; }
        public bool IsSlotFilled { get; set; }
    }
}
