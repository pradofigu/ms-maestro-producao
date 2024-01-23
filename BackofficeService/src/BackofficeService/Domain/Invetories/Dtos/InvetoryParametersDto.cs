namespace BackofficeService.Domain.Invetories.Dtos;

using BackofficeService.Resources;

public sealed class InvetoryParametersDto : BasePaginationParameters
{
    public string? Filters { get; set; }
    public string? SortOrder { get; set; }
}
