namespace BackofficeService.SharedTestHelpers.Fakes.Delivery;

using AutoBogus;
using BackofficeService.Domain.Deliveries;
using BackofficeService.Domain.Deliveries.Models;

public sealed class FakeDeliveryForCreation : AutoFaker<DeliveryForCreation>
{
    public FakeDeliveryForCreation()
    {
    }
}