using Microsoft.EntityFrameworkCore;
using PassIn.Infrastructure.Entities;

namespace PassIn.Infrastructure;

public class PassInDbContext : DbContext
{

    public DbSet<Event> Events { get; set; } // representa tabela de eventos
    public DbSet<Attendee> Attendees { get; set; } // representa tabela de participantes

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) // linca com o banco de dados
    {
        optionsBuilder.UseSqlite("Data Source=C:\\Users\\emanu\\Downloads\\PassInDb.db"); //caminho para o banco
    }
}
