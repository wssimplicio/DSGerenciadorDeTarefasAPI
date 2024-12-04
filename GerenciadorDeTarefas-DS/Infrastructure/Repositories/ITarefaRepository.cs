using GerenciadorDeTarefas_DS.Domain.Models;
using GerenciadorDeTarefas_DS.Infrastructure.Response;

namespace GerenciadorDeTarefas_DS.Infrastructure.Repositories
{
    public interface ITarefaRepository
    {
        Tarefas Add(Tarefas tarefa);

        List<Tarefas> GetAll();

        List<Tarefas> GetByStatus(string status);

        Tarefas GetById(int id);

        Boolean Update(Tarefas tarefa);

        Boolean Delete(Tarefas tarefa);
    }
}
