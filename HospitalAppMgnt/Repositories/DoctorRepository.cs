using HospitalAppMgnt.Data;
using HospitalAppMgnt.Models;
using Microsoft.EntityFrameworkCore;


namespace HospitalAppMgnt.Repositories
{
    public class DoctorRepository:IDoctorRepository
    {
        private readonly ApplicationDbContext _context;

        public DoctorRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<DoctorProfile>> GetDoctorsAsync()
        {
            return await _context.DoctorProfiles.Include(d => d.User).ToListAsync();
        }

        public async Task<DoctorProfile> GetDoctorByIdAsync(int id)
        {
            return await _context.DoctorProfiles.FindAsync(id);
        }

        public async Task<DoctorProfile> CreateDoctorAsync(DoctorProfile doctor)
        {
            _context.DoctorProfiles.Add(doctor);
            await _context.SaveChangesAsync();
            return doctor;
        }

        public async Task<DoctorProfile> UpdateDoctorAsync(DoctorProfile doctor)
        {
            _context.DoctorProfiles.Update(doctor);
            await _context.SaveChangesAsync();
            return doctor;
        }

        public async Task DeleteDoctorAsync(int id)
        {
            var doctor = await _context.DoctorProfiles.FindAsync(id);
            if (doctor != null)
            {
                _context.DoctorProfiles.Remove(doctor);
                await _context.SaveChangesAsync();
            }
        }
    }
}
