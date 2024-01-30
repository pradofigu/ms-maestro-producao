namespace BackofficeService.IntegrationTests.FeatureTests.Invetories;

using BackofficeService.SharedTestHelpers.Fakes.Invetory;
using BackofficeService.Domain.Invetories.Dtos;
using BackofficeService.Domain.Invetories.Features;
using Domain;
using FluentAssertions.Extensions;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

public class UpdateInvetoryCommandTests : TestBase
{
    [Fact]
    public async Task can_update_existing_invetory_in_db()
    {
        // Arrange
        var testingServiceScope = new TestingServiceScope();
        var invetory = new FakeInvetoryBuilder().Build();
        await testingServiceScope.InsertAsync(invetory);
        var updatedInvetoryDto = new FakeInvetoryForUpdateDto().Generate();

        // Act
        var command = new UpdateInvetory.Command(invetory.Id, updatedInvetoryDto);
        await testingServiceScope.SendAsync(command);
        var updatedInvetory = await testingServiceScope
            .ExecuteDbContextAsync(db => db.Invetories
                .FirstOrDefaultAsync(i => i.Id == invetory.Id));

        // Assert
        updatedInvetory.Name.Should().Be(updatedInvetoryDto.Name);
        updatedInvetory.Description.Should().Be(updatedInvetoryDto.Description);
        updatedInvetory.Barcode.Should().Be(updatedInvetoryDto.Barcode);
        updatedInvetory.QuantityInStock.Should().Be(updatedInvetoryDto.QuantityInStock);
        updatedInvetory.UnitOfMeasure.Should().Be(updatedInvetoryDto.UnitOfMeasure);
        updatedInvetory.UnitPrice.Should().BeApproximately(updatedInvetoryDto.UnitPrice, 0.001M);
        updatedInvetory.ExpiryDate.Should().BeCloseTo(updatedInvetoryDto.ExpiryDate, 1.Seconds());
        updatedInvetory.Supplier.Should().Be(updatedInvetoryDto.Supplier);
        updatedInvetory.StockLocation.Should().Be(updatedInvetoryDto.StockLocation);
        updatedInvetory.MinimumStockLevel.Should().Be(updatedInvetoryDto.MinimumStockLevel);
        updatedInvetory.IsActive.Should().Be(updatedInvetoryDto.IsActive);
    }
}