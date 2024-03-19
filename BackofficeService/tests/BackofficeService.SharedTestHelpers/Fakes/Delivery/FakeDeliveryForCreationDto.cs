namespace BackofficeService.SharedTestHelpers.Fakes.Delivery;

using AutoBogus;
using BackofficeService.Domain.Deliveries;
using BackofficeService.Domain.Deliveries.Dtos;

public sealed class FakeDeliveryForCreationDto : AutoFaker<DeliveryForCreationDto>
{
    public FakeDeliveryForCreationDto()
    {
    }
}