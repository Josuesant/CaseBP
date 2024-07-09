namespace Domain.Entities;

public abstract class BaseEntity
{
    public Guid Id { get; private set; }
    public DateTime CriadoEm { get; private set; }
    public DateTime UltomaAtualizacao { get; private set; }

    protected void SetCreate(string requestedBy)
    {
        Id = Guid.NewGuid();
        CriadoEm = DateTime.UtcNow;
    }
    
    protected void SetUpdate()
    {
        UltomaAtualizacao = DateTime.UtcNow;
    }
}