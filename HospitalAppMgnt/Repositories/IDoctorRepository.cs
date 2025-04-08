using HospitalAppMgnt.Models;

namespace HospitalAppMgnt.Repositories
{
    public interface IDoctorRepository
    {
        Task<IEnumerable<DoctorProfile>> GetDoctorsAsync();
        Task<DoctorProfile> GetDoctorByIdAsync(int id);
        Task<DoctorProfile> CreateDoctorAsync(DoctorProfile doctor);
        Task<DoctorProfile> UpdateDoctorAsync(DoctorProfile doctor);
        Task DeleteDoctorAsync(int id);
    }
}
