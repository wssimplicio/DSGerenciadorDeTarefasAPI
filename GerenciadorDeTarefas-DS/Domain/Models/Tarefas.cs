using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GerenciadorDeTarefas_DS.Domain.Models
{
    [Table("tarefas")]
    public class Tarefas
    {
        [Key]
        public int id { get; set; }

        [StringLength(100, ErrorMessage = "O título não pode ter mais de 100 caracteres.")]
        public string titulo { get; set; }

        public string? descricao { get; set; }

        public DateTime datacriacao { get; set; }

        public DateTime? dataconclusao { get; set; }

        public string status { get; set; }

        public enum StatusTarefa
        {
            Pendente,
            EmProgresso,
            Concluido
        }

        public Tarefas(string titulo, string? descricao, DateTime datacriacao, DateTime? dataconclusao, string status)
        {
            this.titulo = titulo;
            this.descricao = descricao;
            this.datacriacao = datacriacao;
            this.dataconclusao = dataconclusao;
            this.status = status;
        }
    }
}
