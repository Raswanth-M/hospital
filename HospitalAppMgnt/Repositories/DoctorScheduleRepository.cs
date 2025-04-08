using HospitalAppMgnt.Data;
using HospitalAppMgnt.DTOs;
using HospitalAppMgnt.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;

namespace HospitalAppMgnt.Repositories
{
    public class DoctorScheduleRepository : IDoctorScheduleRepository
    {
        private readonly ApplicationDbContext _context;

        public DoctorScheduleRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<DoctorSchedule>> GetDoctorSchedulesAsync()
        {
            try
            {
                return await _context.DoctorSchedules.ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Error while fetching all doctor schedules.", ex);
            }
        }

        public async Task<DoctorSchedule> GetDoctorScheduleByIdAsync(int id)
        {
            try
            {
                var doctorSchedule = await _context.DoctorSchedules.FindAsync(id);
                if (doctorSchedule == null)
                {
                    throw new Exception($"Doctor schedule with ID {id} not found.");
                }
                return doctorSchedule;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error while fetching doctor schedule with ID {id}.", ex);
            }
        }

        public async Task<DoctorSchedule> CreateDoctorScheduleAsync(DoctorSchedule doctorSchedule)
        {
            try
            {
                _context.DoctorSchedules.Add(doctorSchedule);
                await _context.SaveChangesAsync();
                return doctorSchedule;
            }
            catch (Exception ex)
            {
                throw new Exception("Error while creating a new doctor schedule.", ex);
            }
        }

        public async Task<DoctorSchedule> UpdateDoctorScheduleAsync(DoctorSchedule doctorSchedule)
        {
            try
            {
                _context.DoctorSchedules.Update(doctorSchedule);
                await _context.SaveChangesAsync();
                return doctorSchedule;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error while updating doctor schedule with ID {doctorSchedule.DoctorId}.", ex);
            }
        }

        public async Task DeleteDoctorScheduleAsync(int id)
        {
            try
            {
                var doctorSchedule = await _context.DoctorSchedules.FindAsync(id);
                if (doctorSchedule == null)
                {
                    throw new Exception($"Doctor schedule with ID {id} not found.");
                }
                _context.DoctorSchedules.Remove(doctorSchedule);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception($"Error while deleting doctor schedule with ID {id}.", ex);
            }
        }
    }
}
