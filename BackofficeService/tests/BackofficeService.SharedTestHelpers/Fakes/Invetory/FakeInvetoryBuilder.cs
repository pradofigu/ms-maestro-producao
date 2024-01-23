namespace BackofficeService.SharedTestHelpers.Fakes.Invetory;

using BackofficeService.Domain.Invetories;
using BackofficeService.Domain.Invetories.Models;

public class FakeInvetoryBuilder
{
    private InvetoryForCreation _creationData = new FakeInvetoryForCreation().Generate();

    public FakeInvetoryBuilder WithModel(InvetoryForCreation model)
    {
        _creationData = model;
        return this;
    }
    
    public FakeInvetoryBuilder WithName(string name)
    {
        _creationData.Name = name;
        return this;
    }
    
    public FakeInvetoryBuilder WithDescription(string description)
    {
        _creationData.Description = description;
        return this;
    }
    
    public FakeInvetoryBuilder WithBarcode(string barcode)
    {
        _creationData.Barcode = barcode;
        return this;
    }
    
    public FakeInvetoryBuilder WithQuantityInStock(int quantityInStock)
    {
        _creationData.QuantityInStock = quantityInStock;
        return this;
    }
    
    public FakeInvetoryBuilder WithUnitOfMeasure(string unitOfMeasure)
    {
        _creationData.UnitOfMeasure = unitOfMeasure;
        return this;
    }
    
    public FakeInvetoryBuilder WithUnitPrice(decimal unitPrice)
    {
        _creationData.UnitPrice = unitPrice;
        return this;
    }
    
    public FakeInvetoryBuilder WithExpiryDate(DateTime expiryDate)
    {
        _creationData.ExpiryDate = expiryDate;
        return this;
    }
    
    public FakeInvetoryBuilder WithSupplier(string supplier)
    {
        _creationData.Supplier = supplier;
        return this;
    }
    
    public FakeInvetoryBuilder WithStockLocation(string stockLocation)
    {
        _creationData.StockLocation = stockLocation;
        return this;
    }
    
    public FakeInvetoryBuilder WithMinimumStockLevel(int minimumStockLevel)
    {
        _creationData.MinimumStockLevel = minimumStockLevel;
        return this;
    }
    
    public FakeInvetoryBuilder WithIsActive(bool isActive)
    {
        _creationData.IsActive = isActive;
        return this;
    }
    
    public Invetory Build()
    {
        var result = Invetory.Create(_creationData);
        return result;
    }
}