namespace BackofficeService.SharedTestHelpers.Fakes.Delivery;

using AutoBogus;
using BackofficeService.Domain.Deliveries;
using BackofficeService.Domain.Deliveries.Models;

public sealed class FakeDeliveryForUpdate : AutoFaker<DeliveryForUpdate>
{
    public FakeDeliveryForUpdate()
    {
    }
}