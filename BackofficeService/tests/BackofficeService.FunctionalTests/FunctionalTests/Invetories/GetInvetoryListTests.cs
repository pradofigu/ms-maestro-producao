namespace BackofficeService.FunctionalTests.FunctionalTests.Invetories;

using BackofficeService.SharedTestHelpers.Fakes.Invetory;
using BackofficeService.FunctionalTests.TestUtilities;
using System.Net;
using System.Threading.Tasks;

public class GetInvetoryListTests : TestBase
{
    [Fact]
    public async Task get_invetory_list_returns_success()
    {
        // Arrange
        

        // Act
        var result = await FactoryClient.GetRequestAsync(ApiRoutes.Invetories.GetList);

        // Assert
        result.StatusCode.Should().Be(HttpStatusCode.OK);
    }
}