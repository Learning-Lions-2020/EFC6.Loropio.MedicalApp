using MedicalApp.Domain;
using MedicalApp.Domain.Contracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalApp.Data.Repository
{
    public class PatientRepository : RecordsRepository<Patient>, IPatientRepository
    {
        private readonly MedicalAppDbContext _context;

        public PatientRepository(MedicalAppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<AppointmentDto>> GetAllPatientsWithAppointmentsAsync()
        {
            return await _context.Appointments
                .Include(a => a.Doctor)
                .Include(a => a.Patient)
                .Select(a => new AppointmentDto
                {
                    PatientName = a.Patient != null ? a.Patient.Name : "Unknown Patient",
                    AppointmentDate = a.Date, 
                    DoctorName = a.Doctor != null ? a.Doctor.Name : "Unknown Doctor"
                })
                .ToListAsync();
        }

        public async Task<IEnumerable<Appointment>> GetAppointmentsForPatientAsync(int patientId)
        {
            return await _context.Appointments
                .Include(a => a.Doctor)
                .Include(a => a.Prescription)
                .Where(a => a.PatientId == patientId)
                .ToListAsync();
        }

        public async Task<IEnumerable<Doctor>> GetDoctorsVisitedByPatientAsync(int patientId)
        {
            return await _context.Doctors
                .Where(d => d.Appointments.Any(a => a.PatientId == patientId))
                .Distinct()
                .ToListAsync();
        }

    }
}
