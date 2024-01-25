namespace BackofficeService.Domain.StockMovements.Mappings;

using BackofficeService.Domain.StockMovements.Dtos;
using BackofficeService.Domain.StockMovements.Models;
using Riok.Mapperly.Abstractions;

[Mapper]
public static partial class StockMovementMapper
{
    public static partial StockMovementForCreation ToStockMovementForCreation(this StockMovementForCreationDto stockMovementForCreationDto);
    public static partial StockMovementForUpdate ToStockMovementForUpdate(this StockMovementForUpdateDto stockMovementForUpdateDto);
    public static partial StockMovementDto ToStockMovementDto(this StockMovement stockMovement);
    public static partial IQueryable<StockMovementDto> ToStockMovementDtoQueryable(this IQueryable<StockMovement> stockMovement);
}