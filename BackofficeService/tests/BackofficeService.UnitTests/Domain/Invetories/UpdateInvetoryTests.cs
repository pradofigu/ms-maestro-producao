namespace BackofficeService.UnitTests.Domain.Invetories;

using BackofficeService.SharedTestHelpers.Fakes.Invetory;
using BackofficeService.Domain.Invetories;
using BackofficeService.Domain.Invetories.DomainEvents;
using Bogus;
using FluentAssertions.Extensions;
using ValidationException = BackofficeService.Exceptions.ValidationException;

public class UpdateInvetoryTests
{
    private readonly Faker _faker;

    public UpdateInvetoryTests()
    {
        _faker = new Faker();
    }
    
    [Fact]
    public void can_update_invetory()
    {
        // Arrange
        var invetory = new FakeInvetoryBuilder().Build();
        var updatedInvetory = new FakeInvetoryForUpdate().Generate();
        
        // Act
        invetory.Update(updatedInvetory);

        // Assert
        invetory.Name.Should().Be(updatedInvetory.Name);
        invetory.Description.Should().Be(updatedInvetory.Description);
        invetory.Barcode.Should().Be(updatedInvetory.Barcode);
        invetory.QuantityInStock.Should().Be(updatedInvetory.QuantityInStock);
        invetory.UnitOfMeasure.Should().Be(updatedInvetory.UnitOfMeasure);
        invetory.UnitPrice.Should().Be(updatedInvetory.UnitPrice);
        invetory.ExpiryDate.Should().BeCloseTo(updatedInvetory.ExpiryDate, 1.Seconds());
        invetory.Supplier.Should().Be(updatedInvetory.Supplier);
        invetory.StockLocation.Should().Be(updatedInvetory.StockLocation);
        invetory.MinimumStockLevel.Should().Be(updatedInvetory.MinimumStockLevel);
        invetory.IsActive.Should().Be(updatedInvetory.IsActive);
    }
    
    [Fact]
    public void queue_domain_event_on_update()
    {
        // Arrange
        var invetory = new FakeInvetoryBuilder().Build();
        var updatedInvetory = new FakeInvetoryForUpdate().Generate();
        invetory.DomainEvents.Clear();
        
        // Act
        invetory.Update(updatedInvetory);

        // Assert
        invetory.DomainEvents.Count.Should().Be(1);
        invetory.DomainEvents.FirstOrDefault().Should().BeOfType(typeof(InvetoryUpdated));
    }
}