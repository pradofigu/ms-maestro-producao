namespace BackofficeService.Domain.StockMovements.DomainEvents;

public sealed class StockMovementUpdated : DomainEvent
{
    public Guid Id { get; set; } 
}
            