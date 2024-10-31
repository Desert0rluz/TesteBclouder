using Microsoft.AspNetCore.Mvc;
using Teste.Bclouder.Business.Interfaces;
using Teste.Bclouder.Business.Entities;

namespace Teste.Bclouder.API.Controllers;

[ApiController]
[Route("api/pessoas")]
public class PersonController : ControllerBase
{
    private readonly IPersonService _personService;
    public PersonController(IPersonService personService)
    {
        _personService = personService;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetByIdGetByIdAsync(Guid id)
    {
        var person = await _personService.GetByIdAsync(id);
        return person == null ? NotFound() : Ok(person);
    }

    [HttpGet]
    public async Task<IActionResult> GetAllAsync()
    {
        var persons = await _personService.GetAllAsync();
        return Ok(persons);
    }
    [HttpPost]
    public async Task<IActionResult> AddAsync([FromBody] Person person)
    {
        await _personService.AddAsync(person);
        return CreatedAtAction(nameof(GetByIdGetByIdAsync), new { id = person.Id }, person);
    }
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateAsync(Guid id, [FromBody] Person person)
    {
        person.Id = id;
        await _personService.UpdateAsync(person);
        return NoContent();
    }
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync(Guid id)
    {
        await _personService.DeleteAsync(id);
        return NoContent();
    }
}
