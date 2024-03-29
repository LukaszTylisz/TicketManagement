﻿using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TicketManagement.Application.Features.TicketType.Commands.Create;
using TicketManagement.Application.Features.TicketType.Commands.Delete;
using TicketManagement.Application.Features.TicketType.Commands.Update;
using TicketManagement.Application.Features.TicketType.Queries.GetAllTickets;
using TicketManagement.Application.Features.TicketType.Queries.GetTicketDetails;

namespace TicketManagement.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public class TicketTypesController(IMediator mediator) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<List<TicketTypeDto>>> Get()
    {
        var ticketTypes = await mediator.Send(new GetTicketTypeQuery());
        return Ok(ticketTypes);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<TicketTypeDetailsDto>> Get(int id)
    {
        var ticketTypes = await mediator.Send(new GetTicketTypeDetailsQuery(id));
        return Ok(ticketTypes);
    }

    [HttpPost]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult> Post(CreateTicketTypeCommand ticketTypeCommand)
    {
        var response = await mediator.Send(ticketTypeCommand);
        return CreatedAtAction(nameof(Get), new { id = response });
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(400)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    public async Task<ActionResult> Put(UpdateTicketTypeCommand ticketTypeCommand)
    {
        await mediator.Send(ticketTypeCommand);
        return NoContent();
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    public async Task<ActionResult> Delete(int id)
    {
        var command = new DeleteTicketTypeCommand() { Id = id };
        await mediator.Send(command);
        return NoContent();
    }
}