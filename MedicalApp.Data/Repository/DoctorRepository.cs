using MedicalApp.Domain;
using MedicalApp.Domain.Contracts;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedicalApp.Data.Repository
{
    public class DoctorRepository : RecordsRepository<Doctor>, IDoctorRepository
    {
        private readonly MedicalAppDbContext _context;

        public DoctorRepository(MedicalAppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Appointment>> GetAppointmentsForDoctorAsync(int doctorId)
        {
            return await _context.Appointments
                .Include(a => a.Patient)
                .Include(a => a.Prescription)
                .Where(a => a.DoctorId == doctorId)
                .ToListAsync();
        }
    }
}

