namespace BackofficeService.Domain.Deliveries.Dtos;

using Destructurama.Attributed;

public sealed record DeliveryForCreationDto
{
    public int Number { get; set; }
    public string Status { get; set; }
    public string CustomerNotes { get; set; }
    public Guid CorrelationId { get; set; }
}
