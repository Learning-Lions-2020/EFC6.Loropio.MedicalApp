using System.Collections.Generic;
using System.Threading.Tasks;

namespace MedicalApp.Domain.Contracts
{
    public interface IRecordsRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync();  // Retrieve all entities
        Task<T> GetByIdAsync(int id);        // Retrieve a single entity by ID
        Task AddAsync(T entity);             // Add a new entity
        Task UpdateAsync(T entity);          // Update an existing entity
        Task DeleteAsync(int id);            // Delete an entity by ID
    }
}
