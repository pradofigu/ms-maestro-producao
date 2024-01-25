namespace SharedKernel.Messages
{
    using System;
    using System.Text;

    public interface IStockDepleted
    {
        public Guid InventoryId { get; set; }
    }

    public class StockDepleted : IStockDepleted
    {
        public Guid InventoryId { get; set; }
    }
}