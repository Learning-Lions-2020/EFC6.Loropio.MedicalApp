using MedicalApp.Domain;
using MedicalApp.Domain.Contracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace MedicalApp.Web.Controllers
{
    [ApiController]
    [Route("api/patients")]
    public class PatientController : ControllerBase
    {
        private readonly IRecordsRepository<Patient> _patientRepository;

        public PatientController(IRecordsRepository<Patient> patientRepository)
        {
            _patientRepository = patientRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllPatients()
        {
            var patients = await _patientRepository.GetAllAsync();
            return Ok(patients);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetPatient(int id)
        {
            var patient = await _patientRepository.GetByIdAsync(id);
            if (patient == null) return NotFound();
            return Ok(patient);
        }

        [HttpPost]
        public async Task<IActionResult> AddPatient([FromBody] Patient patient)
        {
            await _patientRepository.AddAsync(patient);
            return CreatedAtAction(nameof(GetPatient), new { id = patient.Id }, patient);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePatient(int id, [FromBody] Patient patient)
        {
            if (id != patient.Id) return BadRequest();
            await _patientRepository.UpdateAsync(patient);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePatient(int id)
        {
            await _patientRepository.DeleteAsync(id);
            return NoContent();
        }

        [HttpGet("patient/{patientId}/prescriptions")]
        public async Task<IActionResult> GetPrescriptionsForPatient(int patientId)
        {
            var prescriptions = await _patientRepository.GetPrescriptionsForPatientAsync(patientId);
            return Ok(prescriptions);
        }

        [HttpGet("patient/{patientId}/doctors")]
        public async Task<IActionResult> GetDoctorsVisitedByPatient(int patientId)
        {
            var doctors = await _patientRepository.GetDoctorsVisitedByPatientAsync(patientId);
            return Ok(doctors);
        }

    }
}
