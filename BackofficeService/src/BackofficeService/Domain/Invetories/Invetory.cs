namespace BackofficeService.Domain.Invetories;

using System.ComponentModel.DataAnnotations;
using BackofficeService.Domain.StockMovements;
using System.ComponentModel.DataAnnotations.Schema;
using Destructurama.Attributed;
using BackofficeService.Exceptions;
using BackofficeService.Domain.Invetories.Models;
using BackofficeService.Domain.Invetories.DomainEvents;
using BackofficeService.Domain.StockMovements;
using BackofficeService.Domain.StockMovements.Models;


public class Invetory : BaseEntity
{
    public string Name { get; private set; }

    public string Description { get; private set; }

    public string Barcode { get; private set; }

    public int QuantityInStock { get; private set; }

    public string UnitOfMeasure { get; private set; }

    public decimal UnitPrice { get; private set; }

    public DateTime ExpiryDate { get; private set; }

    public string Supplier { get; private set; }

    public string StockLocation { get; private set; }

    public int MinimumStockLevel { get; private set; }

    public bool IsActive { get; private set; }

    private readonly List<StockMovement> _stockMovements = new();
    public IReadOnlyCollection<StockMovement> StockMovements => _stockMovements.AsReadOnly();

    // Add Props Marker -- Deleting this comment will cause the add props utility to be incomplete


    public static Invetory Create(InvetoryForCreation invetoryForCreation)
    {
        var newInvetory = new Invetory();

        newInvetory.Name = invetoryForCreation.Name;
        newInvetory.Description = invetoryForCreation.Description;
        newInvetory.Barcode = invetoryForCreation.Barcode;
        newInvetory.QuantityInStock = invetoryForCreation.QuantityInStock;
        newInvetory.UnitOfMeasure = invetoryForCreation.UnitOfMeasure;
        newInvetory.UnitPrice = invetoryForCreation.UnitPrice;
        newInvetory.ExpiryDate = invetoryForCreation.ExpiryDate;
        newInvetory.Supplier = invetoryForCreation.Supplier;
        newInvetory.StockLocation = invetoryForCreation.StockLocation;
        newInvetory.MinimumStockLevel = invetoryForCreation.MinimumStockLevel;
        newInvetory.IsActive = invetoryForCreation.IsActive;

        newInvetory.QueueDomainEvent(new InvetoryCreated(){ Invetory = newInvetory });
        
        return newInvetory;
    }

    public Invetory Update(InvetoryForUpdate invetoryForUpdate)
    {
        Name = invetoryForUpdate.Name;
        Description = invetoryForUpdate.Description;
        Barcode = invetoryForUpdate.Barcode;
        QuantityInStock = invetoryForUpdate.QuantityInStock;
        UnitOfMeasure = invetoryForUpdate.UnitOfMeasure;
        UnitPrice = invetoryForUpdate.UnitPrice;
        ExpiryDate = invetoryForUpdate.ExpiryDate;
        Supplier = invetoryForUpdate.Supplier;
        StockLocation = invetoryForUpdate.StockLocation;
        MinimumStockLevel = invetoryForUpdate.MinimumStockLevel;
        IsActive = invetoryForUpdate.IsActive;

        QueueDomainEvent(new InvetoryUpdated(){ Id = Id });
        return this;
    }

    public Invetory AddStockMovement(StockMovement stockMovement)
    {
        _stockMovements.Add(stockMovement);
        return this;
    }
    
    public Invetory RemoveStockMovement(StockMovement stockMovement)
    {
        _stockMovements.RemoveAll(x => x.Id == stockMovement.Id);
        return this;
    }

    // Add Prop Methods Marker -- Deleting this comment will cause the add props utility to be incomplete
    
    protected Invetory() { } // For EF + Mocking
}
