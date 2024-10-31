using Teste.Bclouder.Business.Entities;
using Teste.Bclouder.Business.Interfaces;
using Microsoft.EntityFrameworkCore;


namespace Teste.Bclouder.Data.Repository;

internal class ProjectTaskRepository : IProjectTaskRepository
{
    private readonly TesteBclouderDbContext _context;

    public ProjectTaskRepository(TesteBclouderDbContext context)
    {
        _context = context;
    }

    public async Task<ProjectTask> GetByIdAsync(int id)
    {
        return await _context.Tasks.FindAsync(id);
    }
    public async Task<IEnumerable<ProjectTask>> GetAllAsync()
    {
        return await _context.Tasks.ToListAsync();
    }
    public async Task AddAsync(ProjectTask task)
    {
        await _context.Tasks.AddAsync(task);
    }
    public async Task UpdateAsync(ProjectTask task)
    {
        _context.Tasks.Update(task);
        await _context.SaveChangesAsync();
    }
    public async Task DeleteAsync(int id)
    {
        var task = await GetByIdAsync(id);
        if (task != null)
        {
            _context.Tasks.Remove(task);
            await _context.SaveChangesAsync();
        }
    }
    public async Task<IEnumerable<ProjectTask>> GetByPessoaIdAsync(Guid personId)
    {
        if (personId == Guid.Empty)
        {
            throw new ArgumentException("O ID da pessoa não pode ser vazio.", nameof(personId));
        }

        return await _context.Tasks.Where(t => t.PersonId == personId).ToListAsync();
    }
}
