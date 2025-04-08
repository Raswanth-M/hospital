using System.ComponentModel.DataAnnotations;

namespace HospitalAppMgnt.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password{ get; set; }
        public string Role { get; set; }

        //Navigation property
        //public PatientProfile? PatientProfile { get; set; }
        //public DoctorProfile? DoctorProfile { get; set; }
        //public ICollection<Notification>? Notifications { get; set; }

    }
}
