using GerenciadorDeTarefas_DS.Domain.Models;

namespace GerenciadorDeTarefas_DS.Domain.DTO
{
    public class TarefaUpdateDTO
    {

        public string titulo { get; set; }

        public string? descricao { get; set; }

        public DateTime dataconcriacao { get; }

        public DateTime? dataconclusao { get; set; }

        public string status { get; set; }

        public TarefaUpdateDTO(string titulo, string? descricao, DateTime dataconcriacao, DateTime? dataconclusao, string status)
        {
            this.titulo = titulo;
            this.descricao = descricao;
            this.dataconcriacao = dataconcriacao;
            this.dataconclusao = dataconclusao;
            this.status = status;
        }

    }
}
