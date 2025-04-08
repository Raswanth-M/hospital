using System.ComponentModel.DataAnnotations;

namespace HospitalAppMgnt.Models
{
    public class Appointment
    {
        [Key]
        public int Id { get; set; }
        public int PatientId { get; set; }
        public int DoctorId { get; set; }
        public DateTime AppointmentDate { get; set; }
        public string Status { get; set; }

        //Navigation property
        public PatientProfile? Patient { get; set; }
        public DoctorProfile? Doctor { get; set; }
    }
}
