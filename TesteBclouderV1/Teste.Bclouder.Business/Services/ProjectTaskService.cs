using Teste.Bclouder.Business.Entities;
using Teste.Bclouder.Business.Interfaces;

namespace Teste.Bclouder.Business.Services;

public class ProjectTaskService : IProjectTaskService
{
    private readonly IProjectTaskService _projectTaskService;
    public ProjectTaskService(IProjectTaskService projectTaskService)
    {
        _projectTaskService = projectTaskService;
    }
    public async Task<ProjectTask> GetByIdAsync(int id)
    {
        return await _projectTaskService.GetByIdAsync(id);
    }
    public async Task<IEnumerable<ProjectTask>> GetAllAsync()
    {
        return await _projectTaskService.GetAllAsync();
    }
    public async Task AddAsync(ProjectTask task)
    {
        await _projectTaskService.AddAsync(task);
    }
    public async Task UpdateAsync(ProjectTask task)
    {
        await _projectTaskService.UpdateAsync(task);
    }
    public async Task DeleteAsync(int id)
    {
        await _projectTaskService.DeleteAsync(id);
    }
}
