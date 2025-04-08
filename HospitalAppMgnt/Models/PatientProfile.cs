using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HospitalAppMgnt.Models
{
    public class PatientProfile
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string MedicalHistory { get; set; }
        public string ContactDetails { get; set; }

        // Foreign key
        [ForeignKey("UserId")]
        public int UserId { get; set; }

        // Navigation properties
       
        public User? User { get; set; }
        public ICollection<Appointment>? Appointments { get; set; }
        public ICollection<MedicalHistory>? MedicalHistories { get; set; }
    }
}
