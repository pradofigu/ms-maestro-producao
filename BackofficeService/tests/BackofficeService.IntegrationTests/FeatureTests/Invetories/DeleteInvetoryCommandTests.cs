namespace BackofficeService.IntegrationTests.FeatureTests.Invetories;

using BackofficeService.SharedTestHelpers.Fakes.Invetory;
using BackofficeService.Domain.Invetories.Features;
using Microsoft.EntityFrameworkCore;
using Domain;
using System.Threading.Tasks;

public class DeleteInvetoryCommandTests : TestBase
{
    [Fact]
    public async Task can_delete_invetory_from_db()
    {
        // Arrange
        var testingServiceScope = new TestingServiceScope();
        var invetory = new FakeInvetoryBuilder().Build();
        await testingServiceScope.InsertAsync(invetory);

        // Act
        var command = new DeleteInvetory.Command(invetory.Id);
        await testingServiceScope.SendAsync(command);
        var invetoryResponse = await testingServiceScope
            .ExecuteDbContextAsync(db => db.Invetories
                .CountAsync(i => i.Id == invetory.Id));

        // Assert
        invetoryResponse.Should().Be(0);
    }

    [Fact]
    public async Task delete_invetory_throws_notfoundexception_when_record_does_not_exist()
    {
        // Arrange
        var testingServiceScope = new TestingServiceScope();
        var badId = Guid.NewGuid();

        // Act
        var command = new DeleteInvetory.Command(badId);
        Func<Task> act = () => testingServiceScope.SendAsync(command);

        // Assert
        await act.Should().ThrowAsync<NotFoundException>();
    }

    [Fact]
    public async Task can_softdelete_invetory_from_db()
    {
        // Arrange
        var testingServiceScope = new TestingServiceScope();
        var invetory = new FakeInvetoryBuilder().Build();
        await testingServiceScope.InsertAsync(invetory);

        // Act
        var command = new DeleteInvetory.Command(invetory.Id);
        await testingServiceScope.SendAsync(command);
        var deletedInvetory = await testingServiceScope.ExecuteDbContextAsync(db => db.Invetories
            .IgnoreQueryFilters()
            .FirstOrDefaultAsync(x => x.Id == invetory.Id));

        // Assert
        deletedInvetory?.IsDeleted.Should().BeTrue();
    }
}