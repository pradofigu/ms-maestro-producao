namespace BackofficeService.Controllers.v1;

using BackofficeService.Domain.Invetories.Features;
using BackofficeService.Domain.Invetories.Dtos;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using MediatR;

[ApiController]
[Route("api/invetories")]
[ApiVersion("1.0")]
public sealed class InvetoriesController(IMediator mediator) : ControllerBase
{
    /// <summary>
    /// Creates a new Invetory record.
    /// </summary>
    [HttpPost(Name = "AddInvetory")]
    public async Task<ActionResult<InvetoryDto>> AddInvetory([FromBody]InvetoryForCreationDto invetoryForCreation)
    {
        var command = new AddInvetory.Command(invetoryForCreation);
        var commandResponse = await mediator.Send(command);

        return CreatedAtRoute("GetInvetory",
            new { invetoryId = commandResponse.Id },
            commandResponse);
    }


    /// <summary>
    /// Gets a single Invetory by ID.
    /// </summary>
    [HttpGet("{invetoryId:guid}", Name = "GetInvetory")]
    public async Task<ActionResult<InvetoryDto>> GetInvetory(Guid invetoryId)
    {
        var query = new GetInvetory.Query(invetoryId);
        var queryResponse = await mediator.Send(query);
        return Ok(queryResponse);
    }


    /// <summary>
    /// Gets a list of all Invetories.
    /// </summary>
    [HttpGet(Name = "GetInvetories")]
    public async Task<IActionResult> GetInvetories([FromQuery] InvetoryParametersDto invetoryParametersDto)
    {
        var query = new GetInvetoryList.Query(invetoryParametersDto);
        var queryResponse = await mediator.Send(query);

        var paginationMetadata = new
        {
            totalCount = queryResponse.TotalCount,
            pageSize = queryResponse.PageSize,
            currentPageSize = queryResponse.CurrentPageSize,
            currentStartIndex = queryResponse.CurrentStartIndex,
            currentEndIndex = queryResponse.CurrentEndIndex,
            pageNumber = queryResponse.PageNumber,
            totalPages = queryResponse.TotalPages,
            hasPrevious = queryResponse.HasPrevious,
            hasNext = queryResponse.HasNext
        };

        Response.Headers.Add("X-Pagination",
            JsonSerializer.Serialize(paginationMetadata));

        return Ok(queryResponse);
    }


    /// <summary>
    /// Updates an entire existing Invetory.
    /// </summary>
    [HttpPut("{invetoryId:guid}", Name = "UpdateInvetory")]
    public async Task<IActionResult> UpdateInvetory(Guid invetoryId, InvetoryForUpdateDto invetory)
    {
        var command = new UpdateInvetory.Command(invetoryId, invetory);
        await mediator.Send(command);
        return NoContent();
    }


    /// <summary>
    /// Deletes an existing Invetory record.
    /// </summary>
    [HttpDelete("{invetoryId:guid}", Name = "DeleteInvetory")]
    public async Task<ActionResult> DeleteInvetory(Guid invetoryId)
    {
        var command = new DeleteInvetory.Command(invetoryId);
        await mediator.Send(command);
        return NoContent();
    }

    // endpoint marker - do not delete this comment
}
