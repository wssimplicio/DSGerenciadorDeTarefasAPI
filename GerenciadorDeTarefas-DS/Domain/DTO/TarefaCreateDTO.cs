using GerenciadorDeTarefas_DS.Domain.Models;
using System.Diagnostics.CodeAnalysis;

namespace GerenciadorDeTarefas_DS.Domain.DTO
{
    public class TarefaCreateDTO
    {
        public string titulo { get; set; }

        public string? descricao { get; set; }

        public string status { get; set; }

        public TarefaCreateDTO(string titulo, string? descricao, string status)
        {
            this.titulo = titulo;
            this.descricao = descricao;
            this.status = status;
        }

    }
}
