using MedicalApp.Domain;
using MedicalApp.Domain.Contracts;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedicalApp.Data.Repository
{
    public class AppointmentRepository : RecordsRepository<Appointment>, IAppointmentRepository
    {
        private readonly MedicalAppDbContext _context;

        public AppointmentRepository(MedicalAppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Appointment>> GetAppointmentsForPatientAsync(int patientId)
        {
            return await _context.Appointments
                .Include(a => a.Doctor)
                .Include(a => a.Prescription)
                .Where(a => a.PatientId == patientId)
                .ToListAsync();
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

