using BackofficeService.Domain.Deliveries.Dtos;
using BackofficeService.Domain.Deliveries.Mappings;
using BackofficeService.Domain.Deliveries.Services;
using BackofficeService.Domain.Invetories.Services;
using BackofficeService.Services;
using MediatR;

namespace BackofficeService.Domain.Deliveries.Features;

public static class UpdateDelivery
{
    public sealed record Command(Guid DeliveryId, DeliveryForUpdateDto UpdatedDeliveryData) : IRequest;
    
    public sealed class Handler : IRequestHandler<Command>
    {
        private readonly IDeliveryRepository _deliveryRepository;
        private readonly IUnitOfWork _unitOfWork;

        public Handler(IDeliveryRepository deliveryRepository, IUnitOfWork unitOfWork)
        {
            _deliveryRepository = deliveryRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(Command request, CancellationToken cancellationToken)
        {
            var deliveryToUpdate = await _deliveryRepository.GetById(request.DeliveryId, cancellationToken: cancellationToken);
            var deliveryToAdd = request.UpdatedDeliveryData.ToDeliveryForUpdate();
            deliveryToUpdate.Update(deliveryToAdd);

            _deliveryRepository.Update(deliveryToUpdate);
            await _unitOfWork.CommitChanges(cancellationToken);
        }
    }
}