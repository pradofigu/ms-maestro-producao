namespace BackofficeService.SharedTestHelpers.Fakes.StockMovement;

using AutoBogus;
using BackofficeService.Domain.StockMovements;
using BackofficeService.Domain.StockMovements.Models;

public sealed class FakeStockMovementForUpdate : AutoFaker<StockMovementForUpdate>
{
    public FakeStockMovementForUpdate()
    {
    }
}