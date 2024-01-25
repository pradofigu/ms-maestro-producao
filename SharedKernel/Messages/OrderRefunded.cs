namespace SharedKernel.Messages
{
    using System;
    using System.Text;

    public interface IOrderRefunded
    {
        public Guid OrderId { get; set; }
    }

    public class OrderRefunded : IOrderRefunded
    {
        public Guid OrderId { get; set; }
    }
}