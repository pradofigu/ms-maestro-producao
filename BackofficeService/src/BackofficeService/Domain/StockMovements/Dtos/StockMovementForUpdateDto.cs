namespace BackofficeService.Domain.StockMovements.Dtos;

using Destructurama.Attributed;

public sealed record StockMovementForUpdateDto
{
    public DateTime Timestamp { get; set; }
    public int Quantity { get; set; }
    public string MovementType { get; set; }
}
