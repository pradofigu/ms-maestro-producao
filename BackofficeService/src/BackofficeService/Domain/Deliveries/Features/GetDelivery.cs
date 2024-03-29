using BackofficeService.Domain.Deliveries.Dtos;
using BackofficeService.Domain.Deliveries.Mappings;
using BackofficeService.Domain.Deliveries.Services;
using MediatR;

namespace BackofficeService.Domain.Deliveries.Features;

public static class GetDelivery
{
    public sealed record Query(Guid DeliveryId) : IRequest<DeliveryDto>;
    
    public sealed class Handler : IRequestHandler<Query, DeliveryDto>
    {
        private readonly IDeliveryRepository _deliveryRepository;

        public Handler(IDeliveryRepository deliveryRepository)
        {
            _deliveryRepository = deliveryRepository;
        }

        public async Task<DeliveryDto> Handle(Query request, CancellationToken cancellationToken)
        {
            var result = await _deliveryRepository.GetById(request.DeliveryId, cancellationToken: cancellationToken);
            return result.ToDeliveryDto();
        }
    }
}