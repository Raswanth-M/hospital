namespace HospitalAppMgnt.DTOs
{
    public class MedicalHistoryDTO
    {
        public int PatientId { get; set; }
        public string Diagnosis { get; set; }
        public string Treatment { get; set; }
        public DateTime DateOfVisit { get; set; }
    }
}
