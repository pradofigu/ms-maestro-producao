using BackofficeService.Domain.Deliveries;
using MassTransit;
using MediatR;
using SharedKernel.Messages;

namespace BackofficeService.Domain;

public static class OrderCompleted
{
    public sealed record OrderCompletedCommand(Delivery Delivery) : IRequest<bool>;
    
    public sealed class Handler : IRequestHandler<OrderCompletedCommand, bool>
    {
        private readonly IPublishEndpoint _publishEndpoint;

        public Handler(IPublishEndpoint publishEndpoint)
        {
            _publishEndpoint = publishEndpoint;
        }

        public async Task<bool> Handle(OrderCompletedCommand request, CancellationToken cancellationToken)
        {
            await _publishEndpoint.Publish<IOrderCompleted>(new
            {
                request.Delivery.CorrelationId,
                request.Delivery.Number,
                request.Delivery.Status
            }, cancellationToken);

            return true;
        }
    }
}