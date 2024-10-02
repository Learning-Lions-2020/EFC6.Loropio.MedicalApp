using System.Collections.Generic;
using System.Threading.Tasks;

namespace MedicalApp.Domain.Contracts
{
    public interface IRecordsRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync();  
        Task<T> GetByIdAsync(int id);        
        Task AddAsync(T entity);             
        Task UpdateAsync(T entity);          
        Task DeleteAsync(int id);
        Task<List<Appointment>> GetAppointmentsForPatientAsync(int patientId);
    }
}
