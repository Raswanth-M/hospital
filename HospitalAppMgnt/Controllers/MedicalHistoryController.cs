using HospitalAppMgnt.Models;
using HospitalAppMgnt.Repositories;
using Microsoft.AspNetCore.Mvc;
using HospitalAppMgnt.DTOs;

namespace HospitalAppMgnt.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MedicalHistoryController : ControllerBase
    {
        private readonly IMedicalHistoryRepository _medicalHistoryRepository;

        public MedicalHistoryController(IMedicalHistoryRepository medicalHistoryRepository)
        {
            _medicalHistoryRepository = medicalHistoryRepository;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetMedicalHistoryById(int id)
        {
            var medicalHistory = await _medicalHistoryRepository.GetMedicalHistoryByIdAsync(id);
            if (medicalHistory == null)
            {
                return NotFound();
            }
            return Ok(medicalHistory);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllMedicalHistories()
        {
            var medicalHistories = await _medicalHistoryRepository.GetMedicalHistoriesAsync();
            return Ok(medicalHistories);
        }

        [HttpPost]
        public async Task<IActionResult> AddMedicalHistory(MedicalHistoryDTO medicalHistoryDto)
        {
            var medicalHistory = new MedicalHistory
            {
                PatientId = medicalHistoryDto.PatientId,
                Diagnosis = medicalHistoryDto.Diagnosis,
                Treatment = medicalHistoryDto.Treatment,
                DateOfVisit = medicalHistoryDto.DateOfVisit
            };
            await _medicalHistoryRepository.CreateMedicalHistoryAsync(medicalHistory);
            return CreatedAtAction(nameof(GetMedicalHistoryById), new { id = medicalHistory.Id}, medicalHistory);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateMedicalHistory(int id, MedicalHistoryDTO medicalHistoryDto)
        {
            var medicalHistory = await _medicalHistoryRepository.GetMedicalHistoryByIdAsync(id);
            if (medicalHistory == null)
            {
                return NotFound();
            }
            medicalHistory.PatientId = medicalHistoryDto.PatientId;
            medicalHistory.Diagnosis = medicalHistoryDto.Diagnosis;
            medicalHistory.Treatment = medicalHistoryDto.Treatment;
            medicalHistory.DateOfVisit = medicalHistoryDto.DateOfVisit;
            await _medicalHistoryRepository.UpdateMedicalHistoryAsync(medicalHistory);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMedicalHistory(int id)
        {
            await _medicalHistoryRepository.DeleteMedicalHistoryAsync(id);
            return NoContent();
        }
    }

}
