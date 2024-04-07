using Microsoft.EntityFrameworkCore;
using PassIn.Infrastructure.Entities;

namespace PassIn.Infrastructure;

public class PassInDbContext : DbContext
{

    public DbSet<Event> Events { get; set; } // representa tabela de eventos
    public DbSet<Attendee> Attendees { get; set; } // representa tabela de participantes
    public DbSet<CheckIn> CheckIns { get; set; } // representa tabela de checkins

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) // linca com o banco de dados
    {
        optionsBuilder.UseSqlite("Data Source=D:\\git-projetos-pessoais\\nlw-unite\\PassInDb.db"); //caminho para o banco
    }
}
