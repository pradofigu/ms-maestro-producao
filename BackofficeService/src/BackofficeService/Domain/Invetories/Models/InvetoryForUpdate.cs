namespace BackofficeService.Domain.Invetories.Models;

using Destructurama.Attributed;

public sealed record InvetoryForUpdate
{
    public string Name { get; set; }
    public string Description { get; set; }
    public string Barcode { get; set; }
    public int QuantityInStock { get; set; }
    public string UnitOfMeasure { get; set; }
    public decimal UnitPrice { get; set; }
    public DateTime ExpiryDate { get; set; }
    public string Supplier { get; set; }
    public string StockLocation { get; set; }
    public int MinimumStockLevel { get; set; }
    public bool IsActive { get; set; }

}
