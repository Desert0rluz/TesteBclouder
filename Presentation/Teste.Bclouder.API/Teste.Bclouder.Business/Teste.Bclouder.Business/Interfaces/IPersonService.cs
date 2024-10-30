using Teste.Bclouder.Business.Entities;

namespace Teste.Bclouder.Business.Interfaces;

public interface IPersonService
{
    Task<Person> GetByIdAsync(Guid id);
    Task<IEnumerable<Person>> GetAllAsync();
    Task AddAsync(Person person);
    Task UpdateAsync(Person person);
    Task DeleteAsync(Guid id);
}
