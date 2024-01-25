namespace BackofficeService.IntegrationTests.FeatureTests.Invetories;

using BackofficeService.Domain.Invetories.Dtos;
using BackofficeService.SharedTestHelpers.Fakes.Invetory;
using BackofficeService.Domain.Invetories.Features;
using Domain;
using System.Threading.Tasks;

public class InvetoryListQueryTests : TestBase
{
    
    [Fact]
    public async Task can_get_invetory_list()
    {
        // Arrange
        var testingServiceScope = new TestingServiceScope();
        var invetoryOne = new FakeInvetoryBuilder().Build();
        var invetoryTwo = new FakeInvetoryBuilder().Build();
        var queryParameters = new InvetoryParametersDto();

        await testingServiceScope.InsertAsync(invetoryOne, invetoryTwo);

        // Act
        var query = new GetInvetoryList.Query(queryParameters);
        var invetories = await testingServiceScope.SendAsync(query);

        // Assert
        invetories.Count.Should().BeGreaterThanOrEqualTo(2);
    }
}