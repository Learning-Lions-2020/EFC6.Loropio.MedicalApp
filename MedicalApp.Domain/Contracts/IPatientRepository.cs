using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalApp.Domain.Contracts
{
    public interface IPatientRepository : IRecordsRepository<Patient>
    {
        Task<IEnumerable<AppointmentDto>> GetAllPatientsWithAppointmentsAsync();
        Task<IEnumerable<Appointment>> GetAppointmentsForPatientAsync(int patientId);
        Task<IEnumerable<Doctor>> GetDoctorsVisitedByPatientAsync(int patientId);
    }
}
