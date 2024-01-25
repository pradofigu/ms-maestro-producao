namespace BackofficeService.Domain;

using MassTransit;
using SharedKernel.Messages;
using System.Threading.Tasks;
using BackofficeService.Databases;

public sealed class OrderPaid : IConsumer<IOrderPaid>
{
    private readonly BackofficeDbContext _db;

    public OrderPaid(BackofficeDbContext db)
    {
        _db = db;
    }

    public Task Consume(ConsumeContext<IOrderPaid> context)
    {
        // do work here

        return Task.CompletedTask;
    }
}