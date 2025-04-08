using HospitalAppMgnt.Models;

namespace HospitalAppMgnt.Repositories
{
    public interface IDoctorScheduleRepository
    {
        Task<IEnumerable<DoctorSchedule>> GetDoctorSchedulesAsync();
        Task<DoctorSchedule> GetDoctorScheduleByIdAsync(int id);
        Task<DoctorSchedule> CreateDoctorScheduleAsync(DoctorSchedule doctorSchedule);
        Task<DoctorSchedule> UpdateDoctorScheduleAsync(DoctorSchedule doctorSchedule);
        Task DeleteDoctorScheduleAsync(int id);
    }
}
