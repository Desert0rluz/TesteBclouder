using Microsoft.EntityFrameworkCore;
using Teste.Bclouder.Business.Entities;

namespace Teste.Bclouder.Data;

public class TesteBclouderDbContext : DbContext
{
    public DbSet<Person> Persons { get; set; }
    public DbSet<ProjectTask> Tasks { get; set; }

    public TesteBclouderDbContext(DbContextOptions<TesteBclouderDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Person>()
            .HasMany(p => p.Tasks)
            .WithOne(t => t.Person)
            .HasForeignKey(t => t.PersonId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
