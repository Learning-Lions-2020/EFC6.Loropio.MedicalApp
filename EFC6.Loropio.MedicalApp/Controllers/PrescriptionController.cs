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

        [HttpGet]
        public async Task<IActionResult> GetAllPrescriptions()
        {
            var prescriptions = await _prescriptionRepository.GetAllAsync();
            return Ok(prescriptions);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPrescription(int id)
        {
            var prescription = await _prescriptionRepository.GetByIdAsync(id);
            if (prescription == null) return NotFound();
            return Ok(prescription);
        }

        [HttpPost]
        public async Task<IActionResult> AddPrescription([FromBody] Prescription prescription)
        {
            await _prescriptionRepository.AddAsync(prescription);
            return CreatedAtAction(nameof(GetPrescription), new { id = prescription.Id }, prescription);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePrescription(int id, [FromBody] Prescription prescription)
        {
            if (id != prescription.Id) return BadRequest();
            await _prescriptionRepository.UpdateAsync(prescription);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePrescription(int id)
        {
            await _prescriptionRepository.DeleteAsync(id);
            return NoContent();
        }
    }
}
