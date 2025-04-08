using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HospitalAppMgnt.Models
{
    public class DoctorProfile
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Specialization { get; set; }
        public string ContactDetails { get; set; }
        public string Availability { get; set; }

        // Foreign key
        // Navigation properties
       // [ForeignKey("UserId")]
        public int UserId { get; set; }

       
        public User? User { get; set; }
        public ICollection<Appointment>? Appointments { get; set; }
        public ICollection<DoctorSchedule>? DoctorSchedules { get; set; }
    }
}
