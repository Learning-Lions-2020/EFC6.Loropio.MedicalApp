using MedicalApp.Data.Repository;
using MedicalApp.Domain;
using MedicalApp.Domain.Contracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace MedicalApp.Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PatientController : ControllerBase
    {
        private readonly IRecordsRepository<Patient> _patientRepository;
        private readonly IRecordsRepository<Appointment> _appointmentRepository;


        public PatientController(IRecordsRepository<Patient> patientRepository, IRecordsRepository<Appointment> appointmentRepository)
        {
            _patientRepository = patientRepository;
            _appointmentRepository = appointmentRepository;
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

        // GET: api/appointments/patients
        [HttpGet("patients")]
        public async Task<IActionResult> GetAllPatientsWithAppointments()
        {
            var appointments = await _appointmentRepository.GetAllPatientsWithAppointmentsAsync();
            return Ok(appointments);
        }

        [HttpGet("{id}/appointments")]
        public async Task<IActionResult> GetAppointmentsForPatient(int id)
        {
            var appointments = await _patientRepository.GetAppointmentsForPatientAsync(id);
            if (appointments == null)
            {
                return NotFound();
            }
            return Ok(appointments);
        }

        [HttpGet("{id}/doctors")]
        public async Task<IActionResult> GetDoctorsVisitedByPatient(int id)
        {
            var doctors = await _patientRepository.GetDoctorsVisitedByPatientAsync(id);
            if (doctors == null)
            {
                return NotFound();
            }
            return Ok(doctors);
        }



        [HttpGet("patient/{patientId}/prescriptions")]
        public async Task<IActionResult> GetPrescriptionsForPatient(int patientId)
        {
            var prescriptions = await _patientRepository.GetPrescriptionsForPatientAsync(patientId);
            return Ok(prescriptions);
        }

    }
}
