using Teste.Bclouder.Business.Entities;
using Teste.Bclouder.Business.Interfaces;

namespace Teste.Bclouder.Business.Services;

public class PersonService : IPersonService
{
    public readonly IPersonRepository _personRepository;
    public PersonService(IPersonRepository personRepository)
    {
        _personRepository = personRepository;
    }
    public async Task<Person> GetByIdAsync(Guid id)
    {
        return await _personRepository.GetByIdAsync(id);
    }
    public async Task<IEnumerable<Person>> GetAllAsync()
    {
        return await _personRepository.GetAllAsync();
    }
    public async Task AddAsync(Person person)
    {
        await _personRepository.AddAsync(person);
        await _personRepository.CommitAsync();
    }
    public async Task UpdateAsync(Person person)
    {
        await _personRepository.UpdateAsync(person);
    }
    public async Task DeleteAsync(Guid personId)
    {
        bool hasPendingTasks = await _personRepository.HasPendingTasksAsync(personId);

        if (hasPendingTasks)
        {
            throw new InvalidOperationException("Não é possível excluir a pessoa com tarefas pendentes.");
        }

        await _personRepository.DeleteAsync(personId);
    }

}