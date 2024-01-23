namespace BackofficeService.Domain.StockMovements.Dtos;

using BackofficeService.Resources;

public sealed class StockMovementParametersDto : BasePaginationParameters
{
    public string? Filters { get; set; }
    public string? SortOrder { get; set; }
}
