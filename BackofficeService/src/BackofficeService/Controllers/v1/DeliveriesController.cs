using BackofficeService.Domain.Deliveries.Dtos;
using BackofficeService.Domain.Deliveries.Features;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BackofficeService.Controllers.v1;

[ApiController]
[Route("api/deliveries")]
[ApiVersion("1.0")]
public sealed class DeliveriesController(ISender mediator) : ControllerBase
{
    /// <summary>
    /// Gets a single Delivery by ID.
    /// </summary>
    [HttpGet("{DeliveryId:guid}", Name = "GetDelivery")]
    public async Task<ActionResult<DeliveryDto>> GetDelivery(Guid DeliveryId)
    {
        var query = new GetDelivery.Query(DeliveryId);
        var queryResponse = await mediator.Send(query);
        return Ok(queryResponse);
    }
    
    /// <summary>
    /// Updates an entire existing Delivery.
    /// </summary>
    [HttpPut("{DeliveryId:guid}", Name = "UpdateDelivery")]
    public async Task<IActionResult> UpdateDelivery(Guid DeliveryId, DeliveryForUpdateDto Delivery)
    {
        var command = new UpdateDelivery.Command(DeliveryId, Delivery);
        await mediator.Send(command);
        return NoContent();
    }
}