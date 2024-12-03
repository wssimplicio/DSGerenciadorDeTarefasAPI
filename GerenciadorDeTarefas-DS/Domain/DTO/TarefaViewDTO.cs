using GerenciadorDeTarefas_DS.Domain.Models;

namespace GerenciadorDeTarefas_DS.Domain.DTO
{
    public class TarefaViewDTO
    {
        public int id { get; set; }
        public string titulo { get; set; }

        public string? descricao { get; set; }

        public DateTime datacriacao { get; set; }

        public DateTime? dataconclusao { get; set; }

        public string status { get; set; }

        public TarefaViewDTO(int id, string titulo, string? descricao, DateTime datacriacao, DateTime? dataconclusao, string status)
        {
            this.id = id;
            this.titulo = titulo;
            this.descricao = descricao;
            this.datacriacao = datacriacao;
            this.dataconclusao = dataconclusao;
            this.status = status;
        }

    }
}
