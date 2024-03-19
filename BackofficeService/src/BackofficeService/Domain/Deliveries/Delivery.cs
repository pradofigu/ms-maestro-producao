namespace BackofficeService.Domain.Deliveries;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Destructurama.Attributed;
using BackofficeService.Exceptions;
using BackofficeService.Domain.Deliveries.Models;
using BackofficeService.Domain.Deliveries.DomainEvents;


public class Delivery : BaseEntity
{
    public int Number { get; private set; }

    public string Status { get; private set; }

    public string CustomerNotes { get; private set; }

    public Guid CorrelationId { get; private set; }

    // Add Props Marker -- Deleting this comment will cause the add props utility to be incomplete
    
    public static Delivery Create(DeliveryForCreation deliveryForCreation)
    {
        var newDelivery = new Delivery();

        newDelivery.Number = deliveryForCreation.Number;
        newDelivery.Status = deliveryForCreation.Status;
        newDelivery.CustomerNotes = deliveryForCreation.CustomerNotes;
        newDelivery.CorrelationId = deliveryForCreation.CorrelationId;

        newDelivery.QueueDomainEvent(new DeliveryCreated(){ Delivery = newDelivery });
        
        return newDelivery;
    }

    public Delivery Update(DeliveryForUpdate deliveryForUpdate)
    {
        Number = deliveryForUpdate.Number;
        Status = deliveryForUpdate.Status;
        CustomerNotes = deliveryForUpdate.CustomerNotes;
        CorrelationId = deliveryForUpdate.CorrelationId;

        QueueDomainEvent(new DeliveryUpdated(){ Id = Id });
        return this;
    }

    // Add Prop Methods Marker -- Deleting this comment will cause the add props utility to be incomplete
    
    protected Delivery() { } // For EF + Mocking
}