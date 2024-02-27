using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TicketManagement.Application.Features.TicketRequest.Commands.Cancel;
using TicketManagement.Application.Features.TicketRequest.Commands.Change;
using TicketManagement.Application.Features.TicketRequest.Commands.Create;
using TicketManagement.Application.Features.TicketRequest.Commands.Delete;
using TicketManagement.Application.Features.TicketRequest.Commands.Update;
using TicketManagement.Application.Features.TicketRequest.Queries.GetTicketRequestDetails;
using TicketManagement.Application.Features.TicketRequest.Queries.GetTicketRequestList;

namespace TicketManagement.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public class TicketRequestController(IMediator mediator) : ControllerBase

{
    [HttpGet]
    public async Task<ActionResult<List<TicketRequestListDto>>> Get(bool isLoggedInUser = false)
    {
        var ticketRequests = await mediator.Send(new GetTicketRequestListQuery());
        return Ok(ticketRequests);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<TicketRequestDetailsDto>> Get(int id)
    {
        var ticketRequest = await mediator.Send(new GetTicketRequestDetailQuery { Id = id });
        return Ok(ticketRequest);
    }

    [HttpPost]
    [ProducesResponseType(201)]
    [ProducesResponseType(400)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult> Post(CreateTicketRequestCommand ticketRequest)
    {
        var response = await mediator.Send(ticketRequest);
        return CreatedAtAction(nameof(Get), new { id = response });
    }

    [HttpPut]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(400)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    public async Task<ActionResult> Put(UpdateTicketRequestCommand ticketRequest)
    {
        await mediator.Send(ticketRequest);
        return NoContent();
    }

    [HttpPut]
    [Route("CancelRequest")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(400)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    public async Task<ActionResult> CancelRequest(CancelTicketRequestCommand cancelTicketRequest)
    {
        await mediator.Send(cancelTicketRequest);
        return NoContent();
    }

    [HttpPut]
    [Route("UpdateApproval")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(400)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    public async Task<ActionResult> UpdateApproval(ChangeTicketRequestResolvedCommand updateResolvedRequest)
    {
        await mediator.Send(updateResolvedRequest);
        return NoContent();
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    public async Task<ActionResult> Delete(int id)
    {
        var command = new DeleteTicketRequestCommand() { Id = id };
        await mediator.Send(command);
        return NoContent();
    }
}