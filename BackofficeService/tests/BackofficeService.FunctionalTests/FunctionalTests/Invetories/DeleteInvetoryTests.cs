namespace BackofficeService.FunctionalTests.FunctionalTests.Invetories;

using BackofficeService.SharedTestHelpers.Fakes.Invetory;
using BackofficeService.FunctionalTests.TestUtilities;
using System.Net;
using System.Threading.Tasks;

public class DeleteInvetoryTests : TestBase
{
    [Fact]
    public async Task delete_invetory_returns_nocontent_when_entity_exists()
    {
        // Arrange
        var invetory = new FakeInvetoryBuilder().Build();
        await InsertAsync(invetory);

        // Act
        var route = ApiRoutes.Invetories.Delete(invetory.Id);
        var result = await FactoryClient.DeleteRequestAsync(route);

        // Assert
        result.StatusCode.Should().Be(HttpStatusCode.NoContent);
    }
}