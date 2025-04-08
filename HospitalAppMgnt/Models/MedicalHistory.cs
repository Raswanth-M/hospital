using System.ComponentModel.DataAnnotations;

namespace HospitalAppMgnt.Models
{
    public class MedicalHistory
    {
        [Key]
        public int Id { get; set; }
        public int PatientId { get; set; }
        public string Diagnosis { get; set; }
        public string Treatment { get; set; }
        public DateTime DateOfVisit { get; set; }

        //Navigation prop
        public PatientProfile? Patient { get; set; }
    }
}
