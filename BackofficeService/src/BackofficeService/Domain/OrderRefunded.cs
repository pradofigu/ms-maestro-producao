namespace BackofficeService.Domain;

using MassTransit;
using SharedKernel.Messages;
using System.Threading.Tasks;
using BackofficeService.Databases;

public sealed class OrderRefunded : IConsumer<IOrderRefunded>
{
    private readonly BackofficeDbContext _db;

    public OrderRefunded(BackofficeDbContext db)
    {
        _db = db;
    }

    public Task Consume(ConsumeContext<IOrderRefunded> context)
    {
        // do work here

        return Task.CompletedTask;
    }
}