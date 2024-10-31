using Microsoft.AspNetCore.Mvc;
using ProjetoBclouder.Models.Models;
using Data;

namespace ProjetoBclouder.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TarefaController : ControllerBase
    {
        private readonly DAL<Tarefa> _dal;

        public TarefaController(DAL<Tarefa> dal)
        {
            _dal = dal;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Tarefa>> Get()
        {
            var tarefas = _dal.List();
            return Ok(tarefas);
        }

        [HttpGet("{id}")]
        public ActionResult<Tarefa> Get(int id)
        {
            var tarefa = _dal.GetBy(t => t.Id == id);
            if (tarefa == null)
            {
                return NotFound();
            }
            return Ok(tarefa);
        }

        [HttpPost]
        public ActionResult<Tarefa> Create([FromBody] TarefaDTO tarefaDto)
        {
            if (tarefaDto == null)
            {
                return BadRequest("Tarefa não pode ser nula.");
            }
            var tarefa = new Tarefa
            {
                Titulo = tarefaDto.Titulo,
                Descricao = tarefaDto.Descricao,
                Status = tarefaDto.Status,
                PessoaId = tarefaDto.PessoaId,
                DataCriacao = (DateOnly.FromDateTime(DateTime.Now)).ToString("dd/MM/yyyy")
            };

            _dal.Add(tarefa);
            return CreatedAtAction(nameof(Get), new { id = tarefa.Id }, tarefa);
        }

        [HttpPut("{id}")]
        public ActionResult Update(int id, [FromBody] TarefaDTO tarefaDto)
        {
            if (tarefaDto == null)
            {
                return BadRequest("Tarefa inválida.");
            }

            var existingTarefa = _dal.GetBy(t => t.Id == id);
            if (existingTarefa == null)
            {
                return NotFound();
            }

            existingTarefa.Descricao = tarefaDto.Descricao;
            existingTarefa.Status = tarefaDto.Status;
            existingTarefa.PessoaId = tarefaDto.PessoaId;

            _dal.Update(existingTarefa);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var tarefa = _dal.GetBy(t => t.Id == id);
            if (tarefa == null)
            {
                return NotFound();
            }

            if (tarefa.Status != TarefaStatus.completo)
            {
                return BadRequest("A tarefa só pode ser excluída se estiver com status 'Completo'.");
            }

            _dal.Delete(tarefa);
            return NoContent();
        }
    }
}
