namespace HospitalAppMgnt.DTOs
{
    public class PatientProfileDTO
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string MedicalHistory { get; set; }
        public string ContactDetails { get; set; }
    }
}
