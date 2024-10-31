using Teste.Bclouder.Business.Entities;

namespace Teste.Bclouder.Business.Interfaces;

public interface IProjectTaskService
{
    Task<ProjectTask> GetByIdAsync(int id);
    Task<IEnumerable<ProjectTask>> GetAllAsync();
    Task AddAsync(ProjectTask task);
    Task UpdateAsync(ProjectTask task);
    Task DeleteAsync(int id);
}
