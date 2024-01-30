namespace BackofficeService.Domain;

using SharedKernel.Messages;
using MassTransit;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;
using BackofficeService.Databases;

public static class StockDepletedEndpoint
{
    public sealed record StockDepletedEndpointCommand() : IRequest<bool>;

    public sealed class Handler : IRequestHandler<StockDepletedEndpointCommand, bool>
    {
        private readonly IPublishEndpoint _publishEndpoint;
        private readonly BackofficeDbContext _db;

        public Handler(BackofficeDbContext db, IPublishEndpoint publishEndpoint)
        {
            _publishEndpoint = publishEndpoint;
            _db = db;
        }

        public async Task<bool> Handle(StockDepletedEndpointCommand request, CancellationToken cancellationToken)
        {
            await _publishEndpoint.Publish<IStockDepleted>(new { });

            return true;
        }
    }
}