namespace BackofficeService.Domain.Deliveries.DomainEvents;

public sealed class DeliveryUpdated : DomainEvent
{
    public Guid Id { get; set; } 
}
            