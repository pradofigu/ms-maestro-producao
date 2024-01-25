namespace BackofficeService.Domain.StockMovements.DomainEvents;

public sealed class StockMovementCreated : DomainEvent
{
    public StockMovement StockMovement { get; set; } 
}
            