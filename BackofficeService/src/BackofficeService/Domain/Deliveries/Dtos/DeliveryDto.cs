namespace BackofficeService.Domain.Deliveries.Dtos;

using Destructurama.Attributed;

public sealed record DeliveryDto
{
    public Guid Id { get; set; }
    public int Number { get; set; }
    public string Status { get; set; }
    public string CustomerNotes { get; set; }
    public Guid CorrelationId { get; set; }
}
