namespace BackofficeService.UnitTests.Domain.Deliveries;

using BackofficeService.SharedTestHelpers.Fakes.Delivery;
using BackofficeService.Domain.Deliveries;
using BackofficeService.Domain.Deliveries.DomainEvents;
using Bogus;
using FluentAssertions.Extensions;
using ValidationException = BackofficeService.Exceptions.ValidationException;

public class CreateDeliveryTests
{
    private readonly Faker _faker;

    public CreateDeliveryTests()
    {
        _faker = new Faker();
    }
    
    [Fact]
    public void can_create_valid_delivery()
    {
        // Arrange
        var deliveryToCreate = new FakeDeliveryForCreation().Generate();
        
        // Act
        var delivery = Delivery.Create(deliveryToCreate);

        // Assert
        delivery.Number.Should().Be(deliveryToCreate.Number);
        delivery.Status.Should().Be(deliveryToCreate.Status);
        delivery.CustomerNotes.Should().Be(deliveryToCreate.CustomerNotes);
        delivery.CorrelationId.Should().Be(deliveryToCreate.CorrelationId);
    }

    [Fact]
    public void queue_domain_event_on_create()
    {
        // Arrange
        var deliveryToCreate = new FakeDeliveryForCreation().Generate();
        
        // Act
        var delivery = Delivery.Create(deliveryToCreate);

        // Assert
        delivery.DomainEvents.Count.Should().Be(1);
        delivery.DomainEvents.FirstOrDefault().Should().BeOfType(typeof(DeliveryCreated));
    }
}