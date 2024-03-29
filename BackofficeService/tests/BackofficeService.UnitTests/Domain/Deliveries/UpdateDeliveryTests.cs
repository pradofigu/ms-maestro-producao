namespace BackofficeService.UnitTests.Domain.Deliveries;

using BackofficeService.SharedTestHelpers.Fakes.Delivery;
using BackofficeService.Domain.Deliveries;
using BackofficeService.Domain.Deliveries.DomainEvents;
using Bogus;
using FluentAssertions.Extensions;
using ValidationException = BackofficeService.Exceptions.ValidationException;

public class UpdateDeliveryTests
{
    private readonly Faker _faker;

    public UpdateDeliveryTests()
    {
        _faker = new Faker();
    }
    
    [Fact]
    public void can_update_delivery()
    {
        // Arrange
        var delivery = new FakeDeliveryBuilder().Build();
        var updatedDelivery = new FakeDeliveryForUpdate().Generate();
        
        // Act
        delivery.Update(updatedDelivery);

        // Assert
        delivery.Number.Should().Be(updatedDelivery.Number);
        delivery.Status.Should().Be(updatedDelivery.Status);
        delivery.CustomerNotes.Should().Be(updatedDelivery.CustomerNotes);
        delivery.CorrelationId.Should().Be(updatedDelivery.CorrelationId);
    }
    
    [Fact]
    public void queue_domain_event_on_update()
    {
        // Arrange
        var delivery = new FakeDeliveryBuilder().Build();
        var updatedDelivery = new FakeDeliveryForUpdate().Generate();
        delivery.DomainEvents.Clear();
        
        // Act
        delivery.Update(updatedDelivery);

        // Assert
        delivery.DomainEvents.Count.Should().Be(1);
        delivery.DomainEvents.FirstOrDefault().Should().BeOfType(typeof(DeliveryUpdated));
    }
}