namespace BackofficeService.Domain.Deliveries.Dtos;

using BackofficeService.Resources;

public sealed class DeliveryParametersDto : BasePaginationParameters
{
    public string? Filters { get; set; }
    public string? SortOrder { get; set; }
}
