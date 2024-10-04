using MedicalApp.Domain;
using MedicalApp.Domain.Contracts;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace MedicalApp.Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PrescriptionController : ControllerBase
    {
        private readonly IRecordsRepository<Prescription> _prescriptionRepository;

        public PrescriptionController(IRecordsRepository<Prescription> prescriptionRepository)
        {
            _prescriptionRepository = prescriptionRepository;
        }

        // GET: api/prescriptions
        [HttpGet]
        public async Task<IActionResult> GetAllPrescriptions()
        {
            var prescriptions = await _prescriptionRepository.GetAllAsync();
            return Ok(prescriptions);
        }


        // GET: api/prescriptions/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPrescription(int id)
        {
            var prescription = await _prescriptionRepository.GetByIdAsync(id);
            if (prescription == null) return NotFound();
            return Ok(prescription);
        }

        // POST: api/prescriptions
        [HttpPost]
        public async Task<IActionResult> AddPrescription([FromBody] Prescription prescription)
        {
            if (prescription == null)
            {
                return BadRequest("Prescription data is null.");
            }

            await _prescriptionRepository.AddAsync(prescription);
            return CreatedAtAction(nameof(GetPrescription), new { id = prescription.Id }, prescription);
        }

        // PUT: api/prescriptions/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePrescription(int id, [FromBody] Prescription prescription)
        {
            if (id != prescription.Id) return BadRequest();
            await _prescriptionRepository.UpdateAsync(prescription);
            return NoContent();
        }

        // DELETE: api/prescriptions/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePrescription(int id)
        {
            var existingPrescription = await _prescriptionRepository.GetByIdAsync(id);
            if (existingPrescription == null) return NotFound();

            await _prescriptionRepository.DeleteAsync(id);
            return NoContent();
        }


        [HttpGet("patient/{patientId}")]
        public async Task<IActionResult> GetPrescriptionsForPatient(int patientId)
        {
            var prescriptions = await _prescriptionRepository.GetPrescriptionsForPatientAsync(patientId);
            if (prescriptions == null || !prescriptions.Any())
            {
                return NotFound();
            }
            return Ok(prescriptions);
        }
    }
}
