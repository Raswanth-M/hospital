using HospitalAppMgnt.Models;
using HospitalAppMgnt.Repositories;
using Microsoft.AspNetCore.Mvc;
using HospitalAppMgnt.DTOs;
using Microsoft.AspNetCore.Authorization;

namespace HospitalAppMgnt.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DoctorController : ControllerBase
    {
        private readonly IDoctorRepository _doctorRepository;

        public DoctorController(IDoctorRepository doctorRepository)
        {
            _doctorRepository = doctorRepository;
        }

        [Authorize(Roles = "Patient,Doctor")]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetDoctorProfileById(int id)
        {
            var doctorProfile = await _doctorRepository.GetDoctorByIdAsync(id);
            if (doctorProfile == null)
            {
                return NotFound();
            }
            return Ok(doctorProfile);
        }

        [Authorize(Roles = "Patient")]
        [HttpGet]
        public async Task<IActionResult> GetAllDoctorProfiles()
        {
            var doctorProfiles = await _doctorRepository.GetDoctorsAsync();
            return Ok(doctorProfiles);
        }

        [HttpPost]
        public async Task<IActionResult> AddDoctorProfile(DoctorProfileDTO doctorProfileDto)
        {
            var doctorProfile = new DoctorProfile
            {
                Name = doctorProfileDto.Name,
                Specialization = doctorProfileDto.Specialization,
                ContactDetails = doctorProfileDto.ContactDetails,
                Availability = doctorProfileDto.Availability,
                UserId = doctorProfileDto.UserId
            };
            await _doctorRepository.CreateDoctorAsync(doctorProfile);
            return CreatedAtAction(nameof(GetDoctorProfileById), new { id = doctorProfile.Id }, doctorProfile);
        }

        [Authorize(Roles = "Doctor")]
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateDoctorProfile(int id, DoctorProfileDTO doctorProfileDto)
        {
            var doctorProfile = await _doctorRepository.GetDoctorByIdAsync(id);
            if (doctorProfile == null)
            {
                return NotFound();
            }
            doctorProfile.Name = doctorProfileDto.Name;
            doctorProfile.Specialization = doctorProfileDto.Specialization;
            doctorProfile.ContactDetails = doctorProfileDto.ContactDetails;
            doctorProfile.Availability = doctorProfileDto.Availability;
            await _doctorRepository.UpdateDoctorAsync(doctorProfile);
            return NoContent();
        }

        [Authorize(Roles = "Doctor")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDoctorProfile(int id)
        {
            await _doctorRepository.DeleteDoctorAsync(id);
            return NoContent();
        }
    }
}
