namespace BackofficeService.Domain.StockMovements.Models;

using Destructurama.Attributed;

public sealed record StockMovementForUpdate
{
    public DateTime Timestamp { get; set; }
    public int Quantity { get; set; }
    public string MovementType { get; set; }
}
