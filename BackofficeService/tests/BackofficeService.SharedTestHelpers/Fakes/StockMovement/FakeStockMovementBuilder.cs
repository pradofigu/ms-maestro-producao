namespace BackofficeService.SharedTestHelpers.Fakes.StockMovement;

using BackofficeService.Domain.StockMovements;
using BackofficeService.Domain.StockMovements.Models;

public class FakeStockMovementBuilder
{
    private StockMovementForCreation _creationData = new FakeStockMovementForCreation().Generate();

    public FakeStockMovementBuilder WithModel(StockMovementForCreation model)
    {
        _creationData = model;
        return this;
    }
    
    public FakeStockMovementBuilder WithTimestamp(DateTime timestamp)
    {
        _creationData.Timestamp = timestamp;
        return this;
    }
    
    public FakeStockMovementBuilder WithQuantity(int quantity)
    {
        _creationData.Quantity = quantity;
        return this;
    }
    
    public FakeStockMovementBuilder WithMovementType(string movementType)
    {
        _creationData.MovementType = movementType;
        return this;
    }
    
    public StockMovement Build()
    {
        var result = StockMovement.Create(_creationData);
        return result;
    }
}