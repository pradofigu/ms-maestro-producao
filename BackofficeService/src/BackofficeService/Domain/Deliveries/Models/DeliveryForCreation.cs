namespace BackofficeService.Domain.Deliveries.Models;

using Destructurama.Attributed;

public sealed record DeliveryForCreation
{
    public int Number { get; set; }
    public string Status { get; set; }
    public string CustomerNotes { get; set; }
    public Guid CorrelationId { get; set; }
}
