namespace SharedKernel.Messages
{
    using System;

    public interface IOrderCanceled
    {
        public Guid CorrelationId { get; set; }
        public int Number { get; set; }
        public string Status { get; set; }
    }

    public class OrderCanceled : IOrderCanceled
    {
        public Guid CorrelationId { get; set; }
        public int Number { get; set; }
        public string Status { get; set; }
    }
}