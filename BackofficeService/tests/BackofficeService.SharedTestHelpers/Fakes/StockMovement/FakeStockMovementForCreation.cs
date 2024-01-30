namespace BackofficeService.SharedTestHelpers.Fakes.StockMovement;

using AutoBogus;
using BackofficeService.Domain.StockMovements;
using BackofficeService.Domain.StockMovements.Models;

public sealed class FakeStockMovementForCreation : AutoFaker<StockMovementForCreation>
{
    public FakeStockMovementForCreation()
    {
    }
}