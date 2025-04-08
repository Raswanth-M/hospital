using System.ComponentModel.DataAnnotations;

namespace HospitalAppMgnt.Models
{
    public class DoctorSchedule
    {
        [Key]
        public int Id { get; set; }
        public int ScheduleId { get; set; }
        public int DoctorId{ get; set; }
        public string AvailableTimeSlots { get; set; }
        public bool IsSlotFilled { get; set; } = false;

        //Navigation property
        public DoctorProfile? Doctor { get; set; }

        public ICollection<Appointment> Appointments { get; set; }
    }
}
