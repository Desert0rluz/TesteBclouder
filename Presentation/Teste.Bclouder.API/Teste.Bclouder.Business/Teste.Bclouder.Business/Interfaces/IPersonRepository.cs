using Teste.Bclouder.Business.Entities;

namespace Teste.Bclouder.Business.Interfaces;

public interface IPersonRepository
{
    Task<Person> GetByIdAsync(Guid id);
    Task<IEnumerable<Person>> GetAllAsync();
    Task AddAsync(Person person);
    Task UpdateAsync(Person pespersonsoa);
    Task DeleteAsync(Guid id);
    Task<bool> HasPendingTasksAsync(Guid personId);
    Task<int> CommitAsync();
}
