using MediatR;

namespace FootballTicketManagement.Application.Features.TicketAllocation.Queries.GetTicketAllocations;

public class GetTicketTypeListQuery : IRequest<List<TicketAllocationDto>>
{
}