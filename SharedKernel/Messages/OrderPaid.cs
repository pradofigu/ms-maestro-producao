namespace SharedKernel.Messages
{
    using System;
    using System.Text;

    public interface IOrderPaid
    {
        public Guid OrderId { get; set; }
    }

    public class OrderPaid : IOrderPaid
    {
        public Guid OrderId { get; set; }
    }
}