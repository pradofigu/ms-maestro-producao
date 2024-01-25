namespace BackofficeService.IntegrationTests.FeatureTests.Invetories;

using BackofficeService.SharedTestHelpers.Fakes.Invetory;
using Domain;
using FluentAssertions.Extensions;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using BackofficeService.Domain.Invetories.Features;

public class AddInvetoryCommandTests : TestBase
{
    [Fact]
    public async Task can_add_new_invetory_to_db()
    {
        // Arrange
        var testingServiceScope = new TestingServiceScope();
        var invetoryOne = new FakeInvetoryForCreationDto().Generate();

        // Act
        var command = new AddInvetory.Command(invetoryOne);
        var invetoryReturned = await testingServiceScope.SendAsync(command);
        var invetoryCreated = await testingServiceScope.ExecuteDbContextAsync(db => db.Invetories
            .FirstOrDefaultAsync(i => i.Id == invetoryReturned.Id));

        // Assert
        invetoryReturned.Name.Should().Be(invetoryOne.Name);
        invetoryReturned.Description.Should().Be(invetoryOne.Description);
        invetoryReturned.Barcode.Should().Be(invetoryOne.Barcode);
        invetoryReturned.QuantityInStock.Should().Be(invetoryOne.QuantityInStock);
        invetoryReturned.UnitOfMeasure.Should().Be(invetoryOne.UnitOfMeasure);
        invetoryReturned.UnitPrice.Should().BeApproximately(invetoryOne.UnitPrice, 0.001M);
        invetoryReturned.ExpiryDate.Should().BeCloseTo(invetoryOne.ExpiryDate, 1.Seconds());
        invetoryReturned.Supplier.Should().Be(invetoryOne.Supplier);
        invetoryReturned.StockLocation.Should().Be(invetoryOne.StockLocation);
        invetoryReturned.MinimumStockLevel.Should().Be(invetoryOne.MinimumStockLevel);
        invetoryReturned.IsActive.Should().Be(invetoryOne.IsActive);

        invetoryCreated.Name.Should().Be(invetoryOne.Name);
        invetoryCreated.Description.Should().Be(invetoryOne.Description);
        invetoryCreated.Barcode.Should().Be(invetoryOne.Barcode);
        invetoryCreated.QuantityInStock.Should().Be(invetoryOne.QuantityInStock);
        invetoryCreated.UnitOfMeasure.Should().Be(invetoryOne.UnitOfMeasure);
        invetoryCreated.UnitPrice.Should().BeApproximately(invetoryOne.UnitPrice, 0.001M);
        invetoryCreated.ExpiryDate.Should().BeCloseTo(invetoryOne.ExpiryDate, 1.Seconds());
        invetoryCreated.Supplier.Should().Be(invetoryOne.Supplier);
        invetoryCreated.StockLocation.Should().Be(invetoryOne.StockLocation);
        invetoryCreated.MinimumStockLevel.Should().Be(invetoryOne.MinimumStockLevel);
        invetoryCreated.IsActive.Should().Be(invetoryOne.IsActive);
    }
}