using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GerenciadorDeTarefasDS.Migrations
{
    /// <inheritdoc />
    public partial class AddInitialTarefas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
           migrationBuilder.InsertData(
               table: "tarefas",
               columns: new[] { "titulo", "descricao", "datacriacao", "dataconclusao", "status" },
               values: new object[,]
               {
                    { "Tarefa Inicial 1", "Descrição da tarefa 1", DateTime.UtcNow, null, "Pendente" },
                    { "Tarefa Inicial 2", "Descrição da tarefa 2", DateTime.UtcNow, null, "EmProgresso" },
                    { "Tarefa Inicial 3", "Descrição da tarefa 3", DateTime.UtcNow, null, "EmProgresso" },
                    { "Tarefa Inicial 4", "Descrição da tarefa 4", DateTime.UtcNow, null, "Pendente" },
               }
           );
        }
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            
        }
    }
}
