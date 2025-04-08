using HospitalAppMgnt.Models;
using HospitalAppMgnt.Repositories;
using Microsoft.AspNetCore.Mvc;
using HospitalAppMgnt.DTOs;
using Microsoft.AspNetCore.Authorization;

namespace HospitalAppMgnt.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DoctorScheduleController : ControllerBase
    {
        private readonly IDoctorScheduleRepository _doctorScheduleRepository;

        public DoctorScheduleController(IDoctorScheduleRepository doctorScheduleRepository)
        {
            _doctorScheduleRepository = doctorScheduleRepository;
        }

        [Authorize(Roles = "Patient,Doctor")]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetDoctorScheduleById(int id)
        {
            try
            {
                var doctorSchedule = await _doctorScheduleRepository.GetDoctorScheduleByIdAsync(id);
                if (doctorSchedule == null)
                {
                    return NotFound(new { message = "Doctor schedule not found for the given ID." });
                }
                return Ok(doctorSchedule);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "An error occurred while fetching the doctor schedule.", details = ex.InnerException?.Message ?? ex.Message });
            }
        }

        [Authorize(Roles = "Doctor")]
        [HttpGet]
        public async Task<IActionResult> GetAllDoctorSchedules()
        {
            try
            {
                var doctorSchedules = await _doctorScheduleRepository.GetDoctorSchedulesAsync();
                return Ok(doctorSchedules);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "An error occurred while fetching all doctor schedules.", details = ex.InnerException?.Message ?? ex.Message });
            }
        }

        [Authorize(Roles = "Doctor")]
        [HttpPost]
        public async Task<IActionResult> AddDoctorSchedule(DoctorScheduleDTO doctorScheduleDto)
        {
            try
            {
                var doctorSchedule = new DoctorSchedule
                {
                    ScheduleId= doctorScheduleDto.ScheduleId,
                    DoctorId = doctorScheduleDto.DoctorId,
                    AvailableTimeSlots = doctorScheduleDto.AvailableTimeSlots,
                    IsSlotFilled = doctorScheduleDto.IsSlotFilled
                };
                await _doctorScheduleRepository.CreateDoctorScheduleAsync(doctorSchedule);
                return CreatedAtAction(nameof(GetDoctorScheduleById), new { id = doctorSchedule.Id }, doctorSchedule);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "An error occurred while adding the doctor schedule.", details = ex.InnerException?.Message ?? ex.Message });
            }
        }

        [Authorize(Roles = "Doctor")]
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateDoctorSchedule(int id, DoctorScheduleDTO doctorScheduleDto)
        {
            try
            {
                var doctorSchedule = await _doctorScheduleRepository.GetDoctorScheduleByIdAsync(id);
                if (doctorSchedule == null)
                {
                    return NotFound(new { message = "Doctor schedule not found for the given ID." });
                }
                doctorSchedule.DoctorId = doctorScheduleDto.DoctorId;
                doctorSchedule.AvailableTimeSlots = doctorScheduleDto.AvailableTimeSlots;
                doctorSchedule.IsSlotFilled = doctorScheduleDto.IsSlotFilled;
                await _doctorScheduleRepository.UpdateDoctorScheduleAsync(doctorSchedule);
                return Ok(new { message = "Doctor schedule updated successfully." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "An error occurred while updating the doctor schedule.", details = ex.InnerException?.Message ?? ex.Message });
            }
        }

        [Authorize(Roles = "Doctor")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDoctorSchedule(int id)
        {
            try
            {
                var doctorSchedule = await _doctorScheduleRepository.GetDoctorScheduleByIdAsync(id);
                if (doctorSchedule == null)
                {
                    return NotFound(new { message = "Doctor schedule not found for the given ID." });
                }
                await _doctorScheduleRepository.DeleteDoctorScheduleAsync(id);
                return Ok(new { message = "Doctor schedule deleted successfully." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "An error occurred while deleting the doctor schedule.", details = ex.InnerException?.Message ?? ex.Message });
            }
        }
    }
}
