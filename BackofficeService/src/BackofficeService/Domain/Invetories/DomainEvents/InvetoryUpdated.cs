namespace BackofficeService.Domain.Invetories.DomainEvents;

public sealed class InvetoryUpdated : DomainEvent
{
    public Guid Id { get; set; } 
}
            