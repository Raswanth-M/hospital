using HospitalAppMgnt.Data;
using HospitalAppMgnt.Models;
using Microsoft.EntityFrameworkCore;

namespace HospitalAppMgnt.Repositories
{
    public class PatientRepository:IPatientRepository
    {
        private readonly ApplicationDbContext _context;

        public PatientRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<PatientProfile>> GetPatientsAsync()
        {
            return await _context.PatientProfiles.Include(p => p.User).ToListAsync();
        }

        public async Task<PatientProfile> GetPatientByIdAsync(int id)
        {
            return await _context.PatientProfiles.Include(p => p.User).SingleOrDefaultAsync(p => p.Id == id);
        }

        public async Task<PatientProfile> CreatePatientAsync(PatientProfile patient)
        {
            _context.PatientProfiles.Add(patient);
            await _context.SaveChangesAsync();
            return patient;
        }

        public async Task<PatientProfile> UpdatePatientAsync(PatientProfile patient)
        {
            _context.PatientProfiles.Update(patient);
            await _context.SaveChangesAsync();
            return patient;
        }

        public async Task DeletePatientAsync(int id)
        {
            var patient = await _context.PatientProfiles.FindAsync(id);
            if (patient != null)
            {
                _context.PatientProfiles.Remove(patient);
                await _context.SaveChangesAsync();
            }
        }
    }
}
