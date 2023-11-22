using MediatR;

namespace TicketManagement.Application.Features.TicketAllocation.Queries.GetTicketAllocations;

public class GetTicketTypeListQuery : IRequest<List<TicketAllocationDto>>
{
}