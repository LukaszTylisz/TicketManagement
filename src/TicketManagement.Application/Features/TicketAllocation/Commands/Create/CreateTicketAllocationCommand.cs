using MediatR;

namespace TicketManagement.Application.Features.TicketAllocation.Commands.Create;

public class CreateTicketAllocationCommand : IRequest<Unit>
{
    public int TicketTypeId { get; set; }
}