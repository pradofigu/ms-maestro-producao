namespace SharedKernel.Messages
{
    using System;

    public interface IOrderRefunded
    {
        public Guid CorrelationId { get; set; }
        public Guid OrderId { get; set; }
        public int Number { get; set; }
        public string Status { get; set; }
        public string TotalAmount { get; set; }
        public string DiscountCode { get; set; }
    }

    public class OrderRefunded : IOrderRefunded
    {
        public Guid CorrelationId { get; set; }
        public Guid OrderId { get; set; }
        public int Number { get; set; }
        public string Status { get; set; }
        public string TotalAmount { get; set; }
        public string DiscountCode { get; set; }
    }
}