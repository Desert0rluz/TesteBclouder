using Teste.Bclouder.Business.Entities;

namespace Teste.Bclouder.Business.Interfaces;

public interface IProjectTaskRepository
{
    Task<ProjectTask> GetByIdAsync(int id);
    Task<IEnumerable<ProjectTask>> GetAllAsync();
    Task AddAsync(ProjectTask tarefa);
    Task UpdateAsync(ProjectTask tarefa);
    Task DeleteAsync(int id);
    Task<IEnumerable<ProjectTask>> GetByPessoaIdAsync(Guid personId);
}
