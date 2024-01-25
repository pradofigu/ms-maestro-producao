namespace BackofficeService.UnitTests.Domain.Invetories;

using BackofficeService.SharedTestHelpers.Fakes.Invetory;
using BackofficeService.Domain.Invetories;
using BackofficeService.Domain.Invetories.DomainEvents;
using Bogus;
using FluentAssertions.Extensions;
using ValidationException = BackofficeService.Exceptions.ValidationException;

public class CreateInvetoryTests
{
    private readonly Faker _faker;

    public CreateInvetoryTests()
    {
        _faker = new Faker();
    }
    
    [Fact]
    public void can_create_valid_invetory()
    {
        // Arrange
        var invetoryToCreate = new FakeInvetoryForCreation().Generate();
        
        // Act
        var invetory = Invetory.Create(invetoryToCreate);

        // Assert
        invetory.Name.Should().Be(invetoryToCreate.Name);
        invetory.Description.Should().Be(invetoryToCreate.Description);
        invetory.Barcode.Should().Be(invetoryToCreate.Barcode);
        invetory.QuantityInStock.Should().Be(invetoryToCreate.QuantityInStock);
        invetory.UnitOfMeasure.Should().Be(invetoryToCreate.UnitOfMeasure);
        invetory.UnitPrice.Should().Be(invetoryToCreate.UnitPrice);
        invetory.ExpiryDate.Should().BeCloseTo(invetoryToCreate.ExpiryDate, 1.Seconds());
        invetory.Supplier.Should().Be(invetoryToCreate.Supplier);
        invetory.StockLocation.Should().Be(invetoryToCreate.StockLocation);
        invetory.MinimumStockLevel.Should().Be(invetoryToCreate.MinimumStockLevel);
        invetory.IsActive.Should().Be(invetoryToCreate.IsActive);
    }

    [Fact]
    public void queue_domain_event_on_create()
    {
        // Arrange
        var invetoryToCreate = new FakeInvetoryForCreation().Generate();
        
        // Act
        var invetory = Invetory.Create(invetoryToCreate);

        // Assert
        invetory.DomainEvents.Count.Should().Be(1);
        invetory.DomainEvents.FirstOrDefault().Should().BeOfType(typeof(InvetoryCreated));
    }
}