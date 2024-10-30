using Teste.Bclouder.Business.Entities;
using Teste.Bclouder.Business.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Teste.Bclouder.Data.Repository;

internal class PersonRepository : IPersonRepository
{
    private readonly TesteBclouderDbContext _context;

    public PersonRepository(TesteBclouderDbContext context)
    {
        _context = context;
    }

    public async Task<Person> GetByIdAsync(Guid id)
    {
       return await _context.Persons.FindAsync(id);
    }
    public async Task<IEnumerable<Person>> GetAllAsync()
    {
        return await _context.Persons.ToListAsync();
    }
    public async Task AddAsync(Person person)
    {
        await _context.Persons.AddAsync(person);
    }
    public async Task UpdateAsync(Person person)
    {
        _context.Persons.Update(person);
        await _context.SaveChangesAsync();
    }
    public async Task DeleteAsync(Guid id)
    {
        var person = await GetByIdAsync(id);
        if (person != null)
        {
            _context.Persons.Remove(person);
            await _context.SaveChangesAsync();
        }
    }
    public async Task<bool> HasPendingTasksAsync(Guid personId)
    {
        if (personId == Guid.Empty)
        {
            throw new ArgumentException("O ID da pessoa não pode ser vazio.", nameof(personId));
        }
        return await _context.Tasks.AnyAsync(t => t.PersonId == personId && t.Status == ProjectTaskStatus.Pendente);
    }
    public async Task<int> CommitAsync()
    {
        return await _context.SaveChangesAsync();
    }
}
