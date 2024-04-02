using Microsoft.EntityFrameworkCore;
using PassIn.Infrastructure.Entities;

namespace PassIn.Infrastructure;

public class PassInDbContext : DbContext
{

    public DbSet<Event> Events { get; set; } // representa tabela de eventos

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) // linca com o banco de dados
    {
        optionsBuilder.UseSqlite("Data Source=C:\\Users\\emanu\\Downloads\\PassInDb.db"); //caminho para o banco
    }
}
