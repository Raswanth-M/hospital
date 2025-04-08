using HospitalAppMgnt.Models;

namespace HospitalAppMgnt.Repositories
{
    public interface IMedicalHistoryRepository
    {
        Task<IEnumerable<MedicalHistory>> GetMedicalHistoriesAsync();
        Task<MedicalHistory> GetMedicalHistoryByIdAsync(int id);
        Task<MedicalHistory> CreateMedicalHistoryAsync(MedicalHistory medicalHistory);
        Task<MedicalHistory> UpdateMedicalHistoryAsync(MedicalHistory medicalHistory);
        Task DeleteMedicalHistoryAsync(int id);
    }
}
