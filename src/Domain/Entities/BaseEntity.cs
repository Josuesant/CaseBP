namespace Domain.Entities;

public abstract class BaseEntity
{
    public Guid Id { get; private set; }
    public DateTime CriadoEm { get; private set; } = DateTime.Now;
    public DateTime UltomaAtualizacao { get; private set; } = DateTime.Now;

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