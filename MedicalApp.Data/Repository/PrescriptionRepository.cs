using MedicalApp.Domain;
using MedicalApp.Domain.Contracts;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MedicalApp.Data.Repository
{
    public class PrescriptionRepository : RecordsRepository<Prescription>, IPrescriptionRepository
    {
        private readonly MedicalAppDbContext _context;

        public PrescriptionRepository(MedicalAppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Prescription>> GetPrescriptionsForPatientAsync(int patientId)
        {
            return await _context.Prescriptions
                .Include(p => p.Appointment)
                .Where(p => p.Appointment.PatientId == patientId)
                .ToListAsync();
        }
    }
}

