using MediatR;

namespace FootballTicketManagement.Application.Features.TicketAllocation.Queries.GetTitcketAllocationsDetails;

public class GetTicketAllocationsDetailsQuery : IRequest<TicketAllocationsDetailsDto>
{
    public int Id { get; set; }
}