namespace BackofficeService.FunctionalTests.FunctionalTests.Invetories;

using BackofficeService.SharedTestHelpers.Fakes.Invetory;
using BackofficeService.FunctionalTests.TestUtilities;
using System.Net;
using System.Threading.Tasks;

public class CreateInvetoryTests : TestBase
{
    [Fact]
    public async Task create_invetory_returns_created_using_valid_dto()
    {
        // Arrange
        var invetory = new FakeInvetoryForCreationDto().Generate();

        // Act
        var route = ApiRoutes.Invetories.Create;
        var result = await FactoryClient.PostJsonRequestAsync(route, invetory);

        // Assert
        result.StatusCode.Should().Be(HttpStatusCode.Created);
    }
}