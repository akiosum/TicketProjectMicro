namespace TicketProject.Domain.Abstractions;

public abstract class AuditEntity : Entity
{
    public DateTime CreatedDate { get; private set; } = DateTime.UtcNow;
    public DateTime? UpdatedDate { get; private set; }
}