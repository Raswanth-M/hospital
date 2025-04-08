using HospitalAppMgnt.Models;
using HospitalAppMgnt.Repositories;
using Microsoft.AspNetCore.Mvc;
using HospitalAppMgnt.DTOs;
using Microsoft.AspNetCore.Authorization;

namespace HospitalAppMgnt.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PatientProfileController : ControllerBase
    {
        private readonly IPatientRepository _patientProfileRepository;

        public PatientProfileController(IPatientRepository patientProfileRepository)
        {
            _patientProfileRepository = patientProfileRepository;
        }

        [Authorize(Roles = "Patient,Doctor")]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPatientProfileById(int id)
        {
            var patientProfile = await _patientProfileRepository.GetPatientByIdAsync(id);
            if (patientProfile == null)
            {
                return NotFound();
            }
            return Ok(patientProfile);
        }

        [Authorize(Roles = "Doctor")]
        [HttpGet]
        public async Task<IActionResult> GetAllPatientProfiles()
        {
            var patientProfiles = await _patientProfileRepository.GetPatientsAsync();
            return Ok(patientProfiles);
        }

       
        [HttpPost]
        public async Task<IActionResult> AddPatientProfile(PatientProfileDTO patientProfileDto)
        {
            var patientProfile = new PatientProfile
            {
                Name = patientProfileDto.Name,
                DateOfBirth = patientProfileDto.DateOfBirth,
                MedicalHistory = patientProfileDto.MedicalHistory,
                ContactDetails = patientProfileDto.ContactDetails,
                UserId = patientProfileDto.UserId
            };
            await _patientProfileRepository.CreatePatientAsync(patientProfile);
            return CreatedAtAction(nameof(GetPatientProfileById), new { id = patientProfile.Id }, patientProfile);
        }

        [Authorize(Roles = "Patient")]
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePatientProfile(int id, PatientProfileDTO patientProfileDto)
        {
            var patientProfile = await _patientProfileRepository.GetPatientByIdAsync(id);
            if (patientProfile == null)
            {
                return NotFound();
            }
            patientProfile.Name = patientProfileDto.Name;
            patientProfile.DateOfBirth = patientProfileDto.DateOfBirth;
            patientProfile.MedicalHistory = patientProfileDto.MedicalHistory;
            patientProfile.ContactDetails = patientProfileDto.ContactDetails;
            await _patientProfileRepository.UpdatePatientAsync(patientProfile);
            return NoContent();
        }

        [Authorize(Roles = "Patient")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePatientProfile(int id)
        {
            await _patientProfileRepository.DeletePatientAsync(id);
            return NoContent();
        }
    }
}
