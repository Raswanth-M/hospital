using HospitalAppMgnt.Models;

namespace HospitalAppMgnt.Repositories
{
    public interface IPatientRepository
    {
        Task<IEnumerable<PatientProfile>> GetPatientsAsync();
        Task<PatientProfile> GetPatientByIdAsync(int id);
        Task<PatientProfile> CreatePatientAsync(PatientProfile patient);
        Task<PatientProfile> UpdatePatientAsync(PatientProfile patient);
        Task DeletePatientAsync(int id);
    }
}
