using MediatR;
using Microsoft.AspNetCore.Mvc;
using TicketManagement.Application.Features.TicketAllocation.Commands.Create;
using TicketManagement.Application.Features.TicketAllocation.Commands.Delete;
using TicketManagement.Application.Features.TicketAllocation.Commands.Update;
using TicketManagement.Application.Features.TicketAllocation.Queries.GetTicketAllocations;
using TicketManagement.Application.Features.TicketAllocation.Queries.GetTitcketAllocationsDetails;

namespace TicketManagement.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TicketAllocationController : ControllerBase
{
     private readonly IMediator _mediator;
    
        public TicketAllocationController(IMediator mediator)
        {
            _mediator = mediator;
        }
        
        [HttpGet]
        public async Task<ActionResult<List<TicketAllocationDto>>> Get(bool isLoggedInUser = false)
        {
            var ticketAllocations = await _mediator.Send(new GetTicketTypeListQuery());
            return Ok(ticketAllocations);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<TicketAllocationsDetailsDto>> Get(int id)
        {
            var ticketAllocation = await _mediator.Send(new GetTicketAllocationsDetailsQuery() { Id = id });
            return Ok(ticketAllocation);
        }
        
        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> Post(CreateTicketAllocationCommand ticketAllocation)
        {
            var response = await _mediator.Send(ticketAllocation);
            return CreatedAtAction(nameof(Get), new { id = response });
        }
        
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(400)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Put(UpdateTicketAllocationCommand ticketAllocation)
        {
            await _mediator.Send(ticketAllocation);
            return NoContent();
        }
    
        
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Delete(int id)
        {
            var command = new DeleteTicketAllocationCommand { Id = id };
            await _mediator.Send(command);
            return NoContent();
        }
}