using MedicalApp.Domain;
using MedicalApp.Domain.Contracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MedicalApp.Data.Repository
{
    public class RecordsRepository<T> : IRecordsRepository<T> where T : class
    {
        private readonly MedicalAppDbContext _context;
        private readonly DbSet<T> _dbSet;

        public RecordsRepository(MedicalAppDbContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        } 


        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(T entity)
        {
            _dbSet.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _dbSet.FindAsync(id);
            if (entity != null)
            {
                _dbSet.Remove(entity);
                await _context.SaveChangesAsync();
            }
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

        public async Task<IEnumerable<Appointment>> GetAppointmentsWithDetailsAsync()
        {
            return await _context.Appointments
                .Include(a => a.Doctor)
                .Include(a => a.Patient)
                .Include(a => a.Prescription)
                .ToListAsync();
        }


        public async Task<List<AppointmentDto>> GetAppointmentsForPatientAsync(int patientId)
        {
            return await _context.Appointments
                .Include(a => a.Doctor)
                .Include(a => a.Patient)
                .Include(a => a.Prescription)
                .Where(a => a.PatientId == patientId)
                .Select(a => new AppointmentDto
                {
                    PatientId = a.PatientId,
                    PatientName = a.Patient != null ? a.Patient.Name : "Unknown Patient", 
                    DoctorId = a.DoctorId,
                    DoctorName = a.Doctor != null ? a.Doctor.Name : "Unknown Doctor", 
                    PrescriptionId = a.Prescription != null ? a.Prescription.Id : 0, 
                    Medication = a.Prescription != null ? a.Prescription.Medication : "No Medication", 
                    Dosage = a.Prescription != null ? a.Prescription.Dosage : "No Dosage" 
                })
                .ToListAsync();
        }


        public async Task<IEnumerable<Appointment>> GetAppointmentsForDoctorAsync(int doctorId)
        {
            return await _context.Appointments
                .Include(a => a.Doctor)
                .Where(a => a.DoctorId == doctorId)
                .ToListAsync();
        }


        public async Task<IEnumerable<Prescription>> GetPrescriptionsForPatientAsync(int patientId)
        {
            return await _context.Prescriptions
                .Where(p => p.Appointment.PatientId == patientId)
                .ToListAsync();
        }


        public async Task<IEnumerable<Doctor>> GetDoctorsForPatientAsync(int patientId)
        {
            return await _context.Appointments
                .Include(a => a.Doctor)
                .Where(a => a.PatientId == patientId)
                .Select(a => a.Doctor)
                .Distinct()
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
