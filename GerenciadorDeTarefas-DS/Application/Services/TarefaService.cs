using GerenciadorDeTarefas_DS.Domain.DTO;
using GerenciadorDeTarefas_DS.Domain.Models;
using GerenciadorDeTarefas_DS.Infrastructure.Repositories;
using GerenciadorDeTarefas_DS.Infrastructure.Response;

namespace GerenciadorDeTarefas_DS.Application.Services
{
    public class TarefaService
    {
        private readonly ITarefaRepository _tarefaRepository;

        public TarefaService(ITarefaRepository tarefaRepository)
        {
            _tarefaRepository = tarefaRepository ?? throw new ArgumentNullException(nameof(tarefaRepository));
        }

        public ResponseData Add(TarefaCreateDTO tarefaCreateDTO)
        {
            var tarefa = new Tarefas(
               tarefaCreateDTO.titulo,
               tarefaCreateDTO.descricao,
               DateTime.Now,
               null,
               tarefaCreateDTO.status
               );

            if (tarefa.titulo.Length > 100)
            {
                return new ResponseData
                {
                    Success = false,
                    Message = "O título não pode ter mais de 100 caracteres."
                };
            }

            if (!Enum.IsDefined(typeof(Tarefas.StatusTarefa), tarefa.status))
            {
                return new ResponseData
                {
                    Success = false,
                    Message = "Status não definido corretamente",
                };
            }
            var result = _tarefaRepository.Add(tarefa);

            return new ResponseData
            {
                Success = true,
                Data = result,
            };
        }

        public ResponseData GetAll()
        {
            var tarefas = _tarefaRepository.GetAll()
                .Select(t => new TarefaViewDTO
                (
                    t.id,
                    t.titulo,
                    t.descricao,
                    t.datacriacao,
                    t.dataconclusao,
                    t.status
                ))
                .ToList();

            if (tarefas != null)
            {
                return new ResponseData
                {
                    Success = true,
                    Data = tarefas,
                };
            }
            return new ResponseData
            {
                Success = false,
                Message = "Falha ao carregar dados!",
            };
        }

        public ResponseData GetByStatus(string status)
        {
            var tarefas = _tarefaRepository.GetAll()
                .Select(t => new TarefaViewDTO
                (
                    t.id,
                    t.titulo,
                    t.descricao,
                    t.datacriacao,
                    t.dataconclusao,
                    t.status
                ))
                .ToList();

            if(tarefas != null)
            {
                return new ResponseData
                {
                    Success = true,
                    Data = tarefas,
                };
            }
            return new ResponseData
            {
                Success = false,
                Message = "Falha ao carregar dados!",
            };

        }

        public ResponseData Update(int id, TarefaUpdateDTO tarefaUpdateDTO)
        {
            var tarefaExistente = _tarefaRepository.GetById(id);

            if (tarefaExistente != null)
            {
                if (!Enum.IsDefined(typeof(Tarefas.StatusTarefa), tarefaUpdateDTO.status))
                {
                    return new ResponseData
                    {
                        Success = false,
                        Message = "Status não definido corretamente",
                    };
                }
                if (tarefaUpdateDTO.titulo.Length > 100)
                {
                    return new ResponseData
                    {
                        Success = false,
                        Message = "O título não pode ter mais de 100 caracteres."
                    };
                }
                tarefaExistente.titulo = tarefaUpdateDTO.titulo;
                tarefaExistente.descricao = tarefaUpdateDTO.descricao;
                if (tarefaUpdateDTO.status == "Concluido")
                {
                    tarefaExistente.dataconclusao = DateTime.Now;
                }
                tarefaExistente.status = tarefaUpdateDTO.status;

                _tarefaRepository.Update(tarefaExistente);

                return new ResponseData
                {
                    Success = true,
                    Message = "Tarefa Atualizada!"
                };
            }
            return new ResponseData
            {
                Success = false,
                Message = "Tarefa Não encontrada!"
            };
        }

        public ResponseData Delete(int id)
        {
            var retornoTarefa = _tarefaRepository.GetById(id);

            if (retornoTarefa != null)
            {
                _tarefaRepository.Delete(retornoTarefa);

                return new ResponseData
                {
                    Success = true,
                    Message = "Tarefa Deletada!"
                };
            }
            return new ResponseData
            {
                Success = false,
                Message = "Tarefa não encontrada!"
            };
        }
    }
}
