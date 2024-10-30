namespace Teste.Bclouder.Business.Entities;
public class ProjectTask
{
    public Guid Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public ProjectTaskStatus Status { get; set; } = ProjectTaskStatus.Pendente;

    public Guid? PersonId { get; set; }
    public Person? Person { get; set; }
}

public enum ProjectTaskStatus
{
    Pendente,
    Endamento,
    completo
}
