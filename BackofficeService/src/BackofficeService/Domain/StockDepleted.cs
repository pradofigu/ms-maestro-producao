namespace BackofficeService.Domain;

using SharedKernel.Messages;
using MassTransit;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

public static class StockDepleted
{
    public sealed record StockDepletedCommand() : IRequest<bool>;

    public sealed class Handler : IRequestHandler<StockDepletedCommand, bool>
    {
        private readonly IPublishEndpoint _publishEndpoint;

        public Handler(IPublishEndpoint publishEndpoint)
        {
            _publishEndpoint = publishEndpoint;
        }

        public async Task<bool> Handle(StockDepletedCommand request, CancellationToken cancellationToken)
        {
            await _publishEndpoint.Publish<IStockDepleted>(new { });

            return true;
        }
    }
}