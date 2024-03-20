using BackofficeService.Domain.Deliveries;
using BackofficeService.Domain.Deliveries.Dtos;
using BackofficeService.Domain.Deliveries.Mappings;
using BackofficeService.Domain.Deliveries.Services;
using BackofficeService.Services;
using MassTransit;
using SharedKernel.Messages;

namespace BackofficeService.Domain;

public sealed class OrderPaid : IConsumer<IOrderPaid>
{
    private readonly IDeliveryRepository _deliveryRepository;
    private readonly IUnitOfWork _unitOfWork;
    
    public OrderPaid(IDeliveryRepository deliveryRepository, IUnitOfWork unitOfWork)
    {
        _deliveryRepository = deliveryRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task Consume(ConsumeContext<IOrderPaid> context)
    {
        var request = new DeliveryForCreationDto
        {
            CorrelationId = context.Message.CorrelationId,
            Number = context.Message.Number,
            Status = context.Message.Status
        };

        var deliveryToAdd = request.ToDeliveryForCreation();
        var delivery = Delivery.Create(deliveryToAdd);

        await _deliveryRepository.Add(delivery);
        await _unitOfWork.CommitChanges();
    }
}