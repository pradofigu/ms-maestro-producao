using System;

namespace SharedKernel.Messages
{
    public interface IOrderCompleted
    {
        public Guid CorrelationId { get; set; }
        public int Number { get; set; }
        public string Status { get; set; }
    }
    
    public class OrderCompleted : IOrderCompleted
    {
        public Guid CorrelationId { get; set; }
        public int Number { get; set; }
        public string Status { get; set; }
    }
}