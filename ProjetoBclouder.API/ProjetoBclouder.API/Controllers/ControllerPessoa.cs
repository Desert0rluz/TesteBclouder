using Data;
using Microsoft.AspNetCore.Mvc;
using ProjetoBclouder.Models.Models;

namespace ProjetoBclouder.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PessoaController : ControllerBase
{
    private readonly DAL<Pessoa> _dal;
    private readonly DAL<Tarefa> _tarefaDAL;

    public PessoaController(DAL<Pessoa> dal, DAL<Tarefa> tarefaDAL)
    {
        _dal = dal;
        _tarefaDAL = tarefaDAL;
    }

    [HttpGet]
    public ActionResult<IEnumerable<Pessoa>> GetAll()
    {
        var pessoas = _dal.List();
        return Ok(pessoas);
    }

    [HttpGet("{id}")]
    public ActionResult<Pessoa> Get(int id)
    {
        var pessoa = _dal.GetBy(p => p.Id == id);
        if (pessoa == null)
        {
            return NotFound();
        }
        return Ok(pessoa);
    }

    [HttpPost]
    public ActionResult<Pessoa> Create([FromBody] PessoaDTO pessoaDto)
    {
        if (pessoaDto == null)
        {
            return BadRequest("Pessoa não pode ser nula.");
        }

        var pessoa = new Pessoa
        {
            Nome = pessoaDto.Nome,
            Email = pessoaDto.Email,
            DataNascimento = pessoaDto.DataNascimento
        };

        _dal.Add(pessoa);
        return CreatedAtAction(nameof(Get), new { id = pessoa.Id }, pessoa);
    }

    [HttpPut("{id}")]
    public IActionResult Update(int id, [FromBody] PessoaDTO pessoaDto)
    {
        if (pessoaDto == null)
        {
            return BadRequest("Pessoa não pode ser nula.");
        }

        var existingPessoa = _dal.GetBy(p => p.Id == id);
        if (existingPessoa == null)
        {
            return NotFound();
        }

        if (!string.IsNullOrEmpty(pessoaDto.Nome))
        {
            existingPessoa.Nome = pessoaDto.Nome;
        }

        if (!string.IsNullOrEmpty(pessoaDto.Email))
        {
            existingPessoa.Email = pessoaDto.Email;
        }

        if (!string.IsNullOrEmpty(pessoaDto.DataNascimento))
        {
            existingPessoa.DataNascimento = pessoaDto.DataNascimento;
        }

        _dal.Update(existingPessoa);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var pessoa = _dal.GetBy(p => p.Id == id);
        if (pessoa == null)
        {
            return NotFound();
        }

        var temTarefasPendentes = _tarefaDAL.List().Any(t => t.PessoaId == id && t.Status == TarefaStatus.Pendente);
        if (temTarefasPendentes)
        {
            return BadRequest("Não é possível excluir a pessoa com tarefas pendentes.");
        }

        _dal.Delete(pessoa);
        return NoContent();
    }
}
