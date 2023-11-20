using MediatR;

namespace FootballTicketManagement.Application.Features.TicketAllocation.Queries.GetTitcketAllocationDetails;

public class GetTicketAllocationDetailsQuery : IRequest<TicketAllocationDetailsDto>
{
    public int Id { get; set; }
}