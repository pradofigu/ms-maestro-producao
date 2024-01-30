namespace BackofficeService.FunctionalTests.FunctionalTests.Invetories;

using BackofficeService.SharedTestHelpers.Fakes.Invetory;
using BackofficeService.FunctionalTests.TestUtilities;
using System.Net;
using System.Threading.Tasks;

public class UpdateInvetoryRecordTests : TestBase
{
    [Fact]
    public async Task put_invetory_returns_nocontent_when_entity_exists()
    {
        // Arrange
        var invetory = new FakeInvetoryBuilder().Build();
        var updatedInvetoryDto = new FakeInvetoryForUpdateDto().Generate();
        await InsertAsync(invetory);

        // Act
        var route = ApiRoutes.Invetories.Put(invetory.Id);
        var result = await FactoryClient.PutJsonRequestAsync(route, updatedInvetoryDto);

        // Assert
        result.StatusCode.Should().Be(HttpStatusCode.NoContent);
    }
}