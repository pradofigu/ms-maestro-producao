namespace BackofficeService.UnitTests.Domain.StockMovements;

using BackofficeService.SharedTestHelpers.Fakes.StockMovement;
using BackofficeService.Domain.StockMovements;
using BackofficeService.Domain.StockMovements.DomainEvents;
using Bogus;
using FluentAssertions.Extensions;
using ValidationException = BackofficeService.Exceptions.ValidationException;

public class CreateStockMovementTests
{
    private readonly Faker _faker;

    public CreateStockMovementTests()
    {
        _faker = new Faker();
    }
    
    [Fact]
    public void can_create_valid_stockMovement()
    {
        // Arrange
        var stockMovementToCreate = new FakeStockMovementForCreation().Generate();
        
        // Act
        var stockMovement = StockMovement.Create(stockMovementToCreate);

        // Assert
        stockMovement.Timestamp.Should().BeCloseTo(stockMovementToCreate.Timestamp, 1.Seconds());
        stockMovement.Quantity.Should().Be(stockMovementToCreate.Quantity);
        stockMovement.MovementType.Should().Be(stockMovementToCreate.MovementType);
    }

    [Fact]
    public void queue_domain_event_on_create()
    {
        // Arrange
        var stockMovementToCreate = new FakeStockMovementForCreation().Generate();
        
        // Act
        var stockMovement = StockMovement.Create(stockMovementToCreate);

        // Assert
        stockMovement.DomainEvents.Count.Should().Be(1);
        stockMovement.DomainEvents.FirstOrDefault().Should().BeOfType(typeof(StockMovementCreated));
    }
}