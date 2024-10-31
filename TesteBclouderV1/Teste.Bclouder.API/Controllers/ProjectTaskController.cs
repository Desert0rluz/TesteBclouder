using Microsoft.AspNetCore.Mvc;
using Teste.Bclouder.Business.Entities;
using Teste.Bclouder.Business.Interfaces;

namespace Teste.Bclouder.API.Controllers;

[ApiController]
[Route("api/Tarefas")]
public class ProjectTaskController : ControllerBase 
{
    private readonly IProjectTaskService _projectTaskService;
    public ProjectTaskController(IProjectTaskService projectTaskService)
    {
        _projectTaskService = projectTaskService;
    }
    [HttpGet("{id}")]
    public async Task<IActionResult> GetByIdAsync(int id)
    {
        var projectTask = await _projectTaskService.GetByIdAsync(id);
        return projectTask != null ? Ok(projectTask) : NotFound();
    }

    [HttpGet]
    public async Task<IActionResult> GetAllAsync()
    {
        var tasks = await _projectTaskService.GetAllAsync();
        return Ok(tasks);
    }

    [HttpPost]
    public async Task<IActionResult> AddAsync([FromBody] ProjectTask projectTask)
    {
        await _projectTaskService.AddAsync(projectTask);
        return CreatedAtAction(nameof(GetByIdAsync), new { id = projectTask.Id }, projectTask);
    }
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateAsync(Guid id, [FromBody] ProjectTask projectTask)
    {
        projectTask.Id = id;
        await _projectTaskService.UpdateAsync(projectTask);
        return NoContent();
    }
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        await _projectTaskService.DeleteAsync(id);
        return NoContent();
    }
}
