namespace SharedKernel.Messages
{
    using System;

    public interface IOrderPaid
    {
        public Guid CorrelationId { get; set; }
        public int Number { get; set; }
        public string Status { get; set; }
    }

    public class OrderPaid : IOrderPaid
    {
        public Guid CorrelationId { get; set; }
        public int Number { get; set; }
        public string Status { get; set; }
    }
}