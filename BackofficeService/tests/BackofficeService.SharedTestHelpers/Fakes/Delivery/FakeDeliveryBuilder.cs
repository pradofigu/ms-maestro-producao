namespace BackofficeService.SharedTestHelpers.Fakes.Delivery;

using BackofficeService.Domain.Deliveries;
using BackofficeService.Domain.Deliveries.Models;

public class FakeDeliveryBuilder
{
    private DeliveryForCreation _creationData = new FakeDeliveryForCreation().Generate();

    public FakeDeliveryBuilder WithModel(DeliveryForCreation model)
    {
        _creationData = model;
        return this;
    }
    
    public FakeDeliveryBuilder WithNumber(int number)
    {
        _creationData.Number = number;
        return this;
    }
    
    public FakeDeliveryBuilder WithStatus(string status)
    {
        _creationData.Status = status;
        return this;
    }
    
    public FakeDeliveryBuilder WithCustomerNotes(string customerNotes)
    {
        _creationData.CustomerNotes = customerNotes;
        return this;
    }
    
    public FakeDeliveryBuilder WithCorrelationId(Guid correlationId)
    {
        _creationData.CorrelationId = correlationId;
        return this;
    }
    
    public Delivery Build()
    {
        var result = Delivery.Create(_creationData);
        return result;
    }
}