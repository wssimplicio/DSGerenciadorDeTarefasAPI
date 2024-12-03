using GerenciadorDeTarefas_DS.Domain.Models;
using GerenciadorDeTarefas_DS.Infrastructure.Response;

namespace GerenciadorDeTarefas_DS.Infrastructure.Repositories
{
    public interface ITarefaRepository
    {
        ResponseData Add(Tarefas tarefa);

        ResponseData GetAll();

        ResponseData GetByStatus(string status);

        ResponseData Put(int id, Tarefas tarefa);

        ResponseData Delete(int id);
    }
}
