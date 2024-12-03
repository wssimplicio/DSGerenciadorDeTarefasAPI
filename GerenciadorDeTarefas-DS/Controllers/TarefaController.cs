using GerenciadorDeTarefas_DS.Domain.DTO;
using GerenciadorDeTarefas_DS.Domain.Models;
using GerenciadorDeTarefas_DS.Infrastructure.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace GerenciadorDeTarefas_DS.Controllers
{
    [ApiController]
    [Route("api/v1/tarefas")]
    public class TarefaController : Controller
    {

        private readonly ITarefaRepository _tarefaRepository;

        public TarefaController(ITarefaRepository tarefaRepository)
        {
            _tarefaRepository = tarefaRepository ?? throw new ArgumentNullException(nameof(tarefaRepository));
        }

        [HttpPost]
        public IActionResult Add(TarefaCreateDTO tarefaCreateDTO)
        {
            var tarefa = new Tarefas(
                tarefaCreateDTO.titulo,
                tarefaCreateDTO.descricao, 
                DateTime.Now,
                null,
                tarefaCreateDTO.status
                );

            var result = _tarefaRepository.Add( tarefa );

            if (result.Success)
            {
                return Ok(new { message = result.Message, data = result.Data });
            }

            return BadRequest(new { message = result.Message });
        }

        [HttpGet]
        public IActionResult Get()
        {
            var tarefas = _tarefaRepository.GetAll();

            return Ok(tarefas);
        }

        [HttpGet("status/{status}")]
        public IActionResult GetByStatus(string status)
        {
            var tarefas = _tarefaRepository.GetByStatus(status);

            return Ok(tarefas);
        }

        [HttpPut("{id:int}")]
        public IActionResult Put(int id, [FromBody] TarefaUpdateDTO tarefaUpdateDTO) 
        {
            var tarefa = new Tarefas(
                tarefaUpdateDTO.titulo,
                tarefaUpdateDTO.descricao,
                tarefaUpdateDTO.dataconcriacao,
                tarefaUpdateDTO.dataconclusao,
                tarefaUpdateDTO.status
                );

            var result = _tarefaRepository.Put(id, tarefa);
 
            if (result.Success)
            {
                return Ok(new { message = result.Message });
            }

            return BadRequest(new { message = result.Message });
        }

        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id)
        {
            var result = _tarefaRepository.Delete(id);

            if (result.Success)
            {
                return Ok(new { message = result.Message });
            }

            return NotFound(new { message = result.Message });
        }
    }
}
