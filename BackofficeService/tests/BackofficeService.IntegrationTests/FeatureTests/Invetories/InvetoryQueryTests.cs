namespace BackofficeService.IntegrationTests.FeatureTests.Invetories;

using BackofficeService.SharedTestHelpers.Fakes.Invetory;
using BackofficeService.Domain.Invetories.Features;
using Domain;
using FluentAssertions.Extensions;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

public class InvetoryQueryTests : TestBase
{
    [Fact]
    public async Task can_get_existing_invetory_with_accurate_props()
    {
        // Arrange
        var testingServiceScope = new TestingServiceScope();
        var invetoryOne = new FakeInvetoryBuilder().Build();
        await testingServiceScope.InsertAsync(invetoryOne);

        // Act
        var query = new GetInvetory.Query(invetoryOne.Id);
        var invetory = await testingServiceScope.SendAsync(query);

        // Assert
        invetory.Name.Should().Be(invetoryOne.Name);
        invetory.Description.Should().Be(invetoryOne.Description);
        invetory.Barcode.Should().Be(invetoryOne.Barcode);
        invetory.QuantityInStock.Should().Be(invetoryOne.QuantityInStock);
        invetory.UnitOfMeasure.Should().Be(invetoryOne.UnitOfMeasure);
        invetory.UnitPrice.Should().BeApproximately(invetoryOne.UnitPrice, 0.001M);
        invetory.ExpiryDate.Should().BeCloseTo(invetoryOne.ExpiryDate, 1.Seconds());
        invetory.Supplier.Should().Be(invetoryOne.Supplier);
        invetory.StockLocation.Should().Be(invetoryOne.StockLocation);
        invetory.MinimumStockLevel.Should().Be(invetoryOne.MinimumStockLevel);
        invetory.IsActive.Should().Be(invetoryOne.IsActive);
    }

    [Fact]
    public async Task get_invetory_throws_notfound_exception_when_record_does_not_exist()
    {
        // Arrange
        var testingServiceScope = new TestingServiceScope();
        var badId = Guid.NewGuid();

        // Act
        var query = new GetInvetory.Query(badId);
        Func<Task> act = () => testingServiceScope.SendAsync(query);

        // Assert
        await act.Should().ThrowAsync<NotFoundException>();
    }
}