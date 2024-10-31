using Microsoft.EntityFrameworkCore;
using ProjetoBclouder.Models.Models;

namespace Data;

public class ProjetoBclouderDBContext : DbContext
{
    DbSet<Pessoa> Pessoas { get; set; }
    DbSet<Tarefa> Tarefas { get; set; }

    private string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=ProjetoBclouderDB;"+
        "Integrated Security=True;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder
            .UseSqlServer(connectionString)
            .UseLazyLoadingProxies();
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Tarefa>()
            .HasOne<Pessoa>() 
            .WithMany(p => p.Tarefas)
            .HasForeignKey(t => t.PessoaId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}