namespace BackofficeService.FunctionalTests.FunctionalTests.Invetories;

using BackofficeService.SharedTestHelpers.Fakes.Invetory;
using BackofficeService.FunctionalTests.TestUtilities;
using System.Net;
using System.Threading.Tasks;

public class GetInvetoryTests : TestBase
{
    [Fact]
    public async Task get_invetory_returns_success_when_entity_exists()
    {
        // Arrange
        var invetory = new FakeInvetoryBuilder().Build();
        await InsertAsync(invetory);

        // Act
        var route = ApiRoutes.Invetories.GetRecord(invetory.Id);
        var result = await FactoryClient.GetRequestAsync(route);

        // Assert
        result.StatusCode.Should().Be(HttpStatusCode.OK);
    }
}