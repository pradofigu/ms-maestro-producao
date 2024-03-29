using BackofficeService.Domain.Deliveries;
using BackofficeService.Domain.Deliveries.Dtos;
using BackofficeService.Domain.Deliveries.Mappings;
using BackofficeService.Domain.Deliveries.Services;
using BackofficeService.Services;

namespace BackofficeService.Domain;

using MassTransit;
using SharedKernel.Messages;
using System.Threading.Tasks;

public sealed class OrderRefunded : IConsumer<IOrderRefunded>
{
    private readonly IDeliveryRepository _deliveryRepository;
    private readonly IUnitOfWork _unitOfWork;

    public OrderRefunded(IDeliveryRepository deliveryRepository, IUnitOfWork unitOfWork)
    {
        _deliveryRepository = deliveryRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task Consume(ConsumeContext<IOrderRefunded> context)
    {
        // var request = new DeliveryForCreationDto
        // {
        //     CorrelationId = context.Message.CorrelationId,
        //     Number = context.Message.Number,
        //     Status = "Cancelado"
        // };
        //
        // var deliveryToAdd = request.ToDeliveryForCreation();
        // var delivery = Delivery.Create(deliveryToAdd);
        //
        // await _deliveryRepository.Add(delivery);
        // await _unitOfWork.CommitChanges();
    }
}