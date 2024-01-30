namespace BackofficeService.SharedTestHelpers.Fakes.StockMovement;

using AutoBogus;
using BackofficeService.Domain.StockMovements;
using BackofficeService.Domain.StockMovements.Dtos;

public sealed class FakeStockMovementForCreationDto : AutoFaker<StockMovementForCreationDto>
{
    public FakeStockMovementForCreationDto()
    {
    }
}