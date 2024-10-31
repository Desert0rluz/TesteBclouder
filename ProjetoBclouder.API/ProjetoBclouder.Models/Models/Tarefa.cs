namespace ProjetoBclouder.Models.Models;
public class Tarefa
{
    public int Id { get; set; }
    public string Titulo { get; set; } = string.Empty;
    public string Descricao { get; set; } = string.Empty;
    public string? DataCriacao { get; set; }
    public TarefaStatus Status { get; set; } = TarefaStatus.Pendente;
    public int? PessoaId { get; set; }
    public virtual Pessoa? Pessoa { get; set; } 
}
public enum TarefaStatus
{
    Pendente = 0,
    Progresso = 1,
    completo = 2
}
