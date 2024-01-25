namespace BackofficeService.Domain.Invetories.DomainEvents;

public sealed class InvetoryCreated : DomainEvent
{
    public Invetory Invetory { get; set; } 
}
            