namespace ProjetoBclouder.Models.Models;
public class Pessoa
{
    public int Id { get; set; }
    public string Nome { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string? DataNascimento { get; set; } = string.Empty;
    public virtual ICollection<Tarefa> Tarefas { get; set; } = new List<Tarefa>();
}
