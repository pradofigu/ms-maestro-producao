using BackofficeService.Domain.StockMovements.Dtos;

namespace BackofficeService.Domain.Invetories.Dtos;

using Destructurama.Attributed;

public sealed record InvetoryForCreationDto
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
    public List<StockMovementForCreationDto> StockMovement { get; set; }
}
