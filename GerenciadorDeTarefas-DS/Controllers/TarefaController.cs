using GerenciadorDeTarefas_DS.Application.Services;
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

        private readonly TarefaService _tarefaService;

        public TarefaController(TarefaService tarefaService)
        {
            _tarefaService = tarefaService ?? throw new ArgumentNullException(nameof(tarefaService));
        }

        [HttpPost]
        public IActionResult Add(TarefaCreateDTO tarefaCreateDTO)
        {
            var result = _tarefaService.Add(tarefaCreateDTO);

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpGet]
        public IActionResult Get()
        {
            var result = _tarefaService.GetAll();

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpGet("status/{status}")]
        public IActionResult GetByStatus(string status)
        {
            var result = _tarefaService.GetByStatus(status);

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpPut("{id:int}")]
        public IActionResult Update(int id, [FromBody] TarefaUpdateDTO tarefaUpdateDTO) 
        {
            var result = _tarefaService.Update(id, tarefaUpdateDTO);
 
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id)
        {
            var result = _tarefaService.Delete(id);

            if (result.Success)
            {
                return Ok(result);
            }

            return NotFound(result);
        }
    }
}
