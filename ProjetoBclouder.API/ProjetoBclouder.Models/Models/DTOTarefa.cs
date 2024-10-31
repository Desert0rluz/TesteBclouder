namespace ProjetoBclouder.Models.Models;
public class TarefaDTO
{
    public string Titulo { get; set; } = string.Empty;
    public string Descricao { get; set; } = string.Empty;
    public TarefaStatus Status { get; set; }
    public int? PessoaId { get; set; }
}