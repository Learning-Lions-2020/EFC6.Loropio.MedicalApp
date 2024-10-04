using System.Collections.Generic;
using System.Threading.Tasks;

namespace MedicalApp.Domain.Contracts
{
    public interface IAppointmentRepository : IRecordsRepository<Appointment>
    {
        Task<IEnumerable<Appointment>> GetAppointmentsForPatientAsync(int patientId);
        Task<IEnumerable<Appointment>> GetAppointmentsForDoctorAsync(int doctorId);
    }
}

