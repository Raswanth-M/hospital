using HospitalAppMgnt.Data;
using HospitalAppMgnt.Models;
using Microsoft.EntityFrameworkCore;

namespace HospitalAppMgnt.Repositories
{
    public class MedicalHistoryRepository:IMedicalHistoryRepository
    {
        private readonly ApplicationDbContext _context;

        public MedicalHistoryRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<MedicalHistory>> GetMedicalHistoriesAsync()
        {
            return await _context.MedicalHistories.ToListAsync();
        }

        public async Task<MedicalHistory> GetMedicalHistoryByIdAsync(int id)
        {
            return await _context.MedicalHistories.FindAsync(id);
        }

        public async Task<MedicalHistory> CreateMedicalHistoryAsync(MedicalHistory medicalHistory)
        {
            _context.MedicalHistories.Add(medicalHistory);
            await _context.SaveChangesAsync();
            return medicalHistory;
        }

        public async Task<MedicalHistory> UpdateMedicalHistoryAsync(MedicalHistory medicalHistory)
        {
            _context.MedicalHistories.Update(medicalHistory);
            await _context.SaveChangesAsync();
            return medicalHistory;
        }

        public async Task DeleteMedicalHistoryAsync(int id)
        {
            var medicalHistory = await _context.MedicalHistories.FindAsync(id);
            if (medicalHistory != null)
            {
                _context.MedicalHistories.Remove(medicalHistory);
                await _context.SaveChangesAsync();
            }
        }
    }
}
