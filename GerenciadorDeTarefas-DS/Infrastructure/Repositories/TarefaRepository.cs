using GerenciadorDeTarefas_DS.Domain.DTO;
using GerenciadorDeTarefas_DS.Domain.Models;
using GerenciadorDeTarefas_DS.Infrastructure.Response;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;

namespace GerenciadorDeTarefas_DS.Infrastructure.Repositories
{
    public class TarefaRepository : ITarefaRepository
    {
        private readonly DbConnection _connection;
        public TarefaRepository(DbConnection connection)
        {
            _connection = connection ?? throw new ArgumentNullException(nameof(connection));
        }

        public ResponseData Add(Tarefas tarefa)
        {
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
            _connection.Tarefas.Add(tarefa);
            var ret = _connection.SaveChanges();

            return new ResponseData
            {
                Success = true,
                Data = tarefa,
            };

        }

        public ResponseData GetByStatus(string status)
        {
            return new ResponseData
            {
                Success = true,
                Data = _connection.Tarefas
                .Where(t => t.status == status)
                .ToList()
            };
        }

        public ResponseData GetAll()
        {
            var listagem = _connection.Tarefas
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

            return new ResponseData
            {
                Success = true,
                Data = listagem
            };
        }

        public ResponseData Put(int id, Tarefas tarefa)
        {
            var tarefaExistente = _connection.Tarefas.Find(id);

            if (tarefaExistente != null)
            {
                if (!Enum.IsDefined(typeof(Tarefas.StatusTarefa), tarefa.status))
                {
                    return new ResponseData
                    {
                        Success = false,
                        Message = "Status não definido corretamente",
                    };
                }
                if (tarefa.titulo.Length > 100)
                {
                    return new ResponseData
                    {
                        Success = false,
                        Message = "O título não pode ter mais de 100 caracteres."
                    };
                }
                tarefaExistente.titulo = tarefa.titulo;
                tarefaExistente.descricao = tarefa.descricao;
                if (tarefa.status == "Concluido")
                {
                    tarefaExistente.dataconclusao = DateTime.Now;
                }
                tarefaExistente.status = tarefa.status;

                _connection.Tarefas.Update(tarefaExistente);
                _connection.SaveChanges();

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
            var tarefa = _connection.Tarefas.Find(id);

            if (tarefa != null)
            {
               _connection.Tarefas.Remove(tarefa);
               _connection.SaveChanges();
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
