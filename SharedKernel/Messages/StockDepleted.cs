namespace SharedKernel.Messages
{
    using System;

    public interface IStockDepleted
    {
        public Guid InventoryId { get; set; }
    }

    public class StockDepleted : IStockDepleted
    {
        public Guid InventoryId { get; set; }
    }
}