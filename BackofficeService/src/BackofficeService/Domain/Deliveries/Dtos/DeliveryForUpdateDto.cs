using System.Text.Json.Serialization;

namespace BackofficeService.Domain.Deliveries.Dtos;

using Destructurama.Attributed;

public sealed record DeliveryForUpdateDto
{
    [JsonIgnore]
    public int Number { get; set; }
    public string Status { get; set; }
    [JsonIgnore]
    public string CustomerNotes { get; set; }
    public Guid CorrelationId { get; set; }
}
