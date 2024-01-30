namespace BackofficeService.Extensions.Services.ProducerRegistrations;

using MassTransit;
using MassTransit.RabbitMqTransport;
using SharedKernel.Messages;
using RabbitMQ.Client;

public static class StockDepletedEndpointRegistration
{
    public static void StockDepletedEndpoint(this IRabbitMqBusFactoryConfigurator cfg)
    {
        cfg.Message<IStockDepleted>(e => e.SetEntityName("stock-depleted")); // name of the primary exchange
        cfg.Publish<IStockDepleted>(e => e.ExchangeType = ExchangeType.Fanout); // primary exchange type
    }
}