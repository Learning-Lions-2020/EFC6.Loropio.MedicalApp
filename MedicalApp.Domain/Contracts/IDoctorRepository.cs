using System.Collections.Generic;
using System.Threading.Tasks;

namespace MedicalApp.Domain.Contracts
{
    public interface IDoctorRepository : IRecordsRepository<Doctor>
    {
        Task<IEnumerable<Appointment>> GetAppointmentsForDoctorAsync(int doctorId);
    }
}

