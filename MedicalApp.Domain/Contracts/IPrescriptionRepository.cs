using System.Collections.Generic;
using System.Threading.Tasks;

namespace MedicalApp.Domain.Contracts
{
    public interface IPrescriptionRepository : IRecordsRepository<Prescription>
    {
        Task<IEnumerable<Prescription>> GetPrescriptionsForPatientAsync(int patientId);
    }
}

