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

        public Tarefas Add(Tarefas tarefa)
        {
            
            _connection.Tarefas.Add(tarefa);
            _connection.SaveChanges();

            return tarefa;

        }

        public List<Tarefas> GetByStatus(string status)
        {
            return _connection.Tarefas.Where(t => t.status == status).ToList();
        }

        public List<Tarefas> GetAll()
        {
            return _connection.Tarefas.ToList();
        }

        public Tarefas GetById(int id)
        {
            return _connection.Tarefas.Find(id);
        }

        public Boolean Update(Tarefas tarefa)
        {
            _connection.Tarefas.Update(tarefa);
            _connection.SaveChanges();

            return true;
        }

        public Boolean Delete(Tarefas tarefa)
        {
            _connection.Tarefas.Remove(tarefa);
            _connection.SaveChanges();

            return true;
        }
    }
}
