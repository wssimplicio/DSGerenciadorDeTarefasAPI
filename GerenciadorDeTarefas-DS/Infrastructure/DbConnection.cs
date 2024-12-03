using GerenciadorDeTarefas_DS.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace GerenciadorDeTarefas_DS.Infrastructure
{
    public class DbConnection : DbContext
    {
        public DbSet<Tarefas> Tarefas { get; set; }
        public DbConnection(DbContextOptions<DbConnection> options) : base(options) { }

        /*protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseSqlServer(
                "Server=localhost,1433;Database=ds_tarefas;User ID=sa;Password=12345678;Trusted_Connection=False; TrustServerCertificate=True;"
                );*/
    }
}
