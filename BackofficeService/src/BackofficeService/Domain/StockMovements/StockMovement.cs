namespace BackofficeService.Domain.StockMovements;

using System.ComponentModel.DataAnnotations;
using BackofficeService.Domain.Invetories;
using System.ComponentModel.DataAnnotations.Schema;
using Destructurama.Attributed;
using BackofficeService.Exceptions;
using BackofficeService.Domain.StockMovements.Models;
using BackofficeService.Domain.StockMovements.DomainEvents;


public class StockMovement : BaseEntity
{
    public DateTime Timestamp { get; private set; }

    public int Quantity { get; private set; }

    public string MovementType { get; private set; }

    public Invetory Invetory { get; }

    // Add Props Marker -- Deleting this comment will cause the add props utility to be incomplete


    public static StockMovement Create(StockMovementForCreation stockMovementForCreation)
    {
        var newStockMovement = new StockMovement();

        newStockMovement.Timestamp = stockMovementForCreation.Timestamp;
        newStockMovement.Quantity = stockMovementForCreation.Quantity;
        newStockMovement.MovementType = stockMovementForCreation.MovementType;

        newStockMovement.QueueDomainEvent(new StockMovementCreated(){ StockMovement = newStockMovement });
        
        return newStockMovement;
    }

    public StockMovement Update(StockMovementForUpdate stockMovementForUpdate)
    {
        Timestamp = stockMovementForUpdate.Timestamp;
        Quantity = stockMovementForUpdate.Quantity;
        MovementType = stockMovementForUpdate.MovementType;

        QueueDomainEvent(new StockMovementUpdated(){ Id = Id });
        return this;
    }

    // Add Prop Methods Marker -- Deleting this comment will cause the add props utility to be incomplete
    
    protected StockMovement() { } // For EF + Mocking
}
