using MassTransit;
using RabbitMQ.Client;
using SharedKernel.Messages;

namespace BackofficeService.Extensions.Services.ProducerRegistrations;

public static class OrderCompletedEndpointRegistration
{
    public static void OrderCompletedEndpoint(this IRabbitMqBusFactoryConfigurator cfg)
    {
        cfg.Message<IOrderCompleted>(e => e.SetEntityName("order-completed")); // name of the primary exchange
        cfg.Publish<IOrderCompleted>(e => e.ExchangeType = ExchangeType.Fanout); // primary exchange type
    }
}