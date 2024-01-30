namespace BackofficeService.UnitTests.Domain.StockMovements;

using BackofficeService.SharedTestHelpers.Fakes.StockMovement;
using BackofficeService.Domain.StockMovements;
using BackofficeService.Domain.StockMovements.DomainEvents;
using Bogus;
using FluentAssertions.Extensions;
using ValidationException = BackofficeService.Exceptions.ValidationException;

public class UpdateStockMovementTests
{
    private readonly Faker _faker;

    public UpdateStockMovementTests()
    {
        _faker = new Faker();
    }
    
    [Fact]
    public void can_update_stockMovement()
    {
        // Arrange
        var stockMovement = new FakeStockMovementBuilder().Build();
        var updatedStockMovement = new FakeStockMovementForUpdate().Generate();
        
        // Act
        stockMovement.Update(updatedStockMovement);

        // Assert
        stockMovement.Timestamp.Should().BeCloseTo(updatedStockMovement.Timestamp, 1.Seconds());
        stockMovement.Quantity.Should().Be(updatedStockMovement.Quantity);
        stockMovement.MovementType.Should().Be(updatedStockMovement.MovementType);
    }
    
    [Fact]
    public void queue_domain_event_on_update()
    {
        // Arrange
        var stockMovement = new FakeStockMovementBuilder().Build();
        var updatedStockMovement = new FakeStockMovementForUpdate().Generate();
        stockMovement.DomainEvents.Clear();
        
        // Act
        stockMovement.Update(updatedStockMovement);

        // Assert
        stockMovement.DomainEvents.Count.Should().Be(1);
        stockMovement.DomainEvents.FirstOrDefault().Should().BeOfType(typeof(StockMovementUpdated));
    }
}