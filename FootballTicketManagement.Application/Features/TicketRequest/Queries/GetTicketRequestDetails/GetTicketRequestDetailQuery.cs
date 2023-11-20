using MediatR;

namespace FootballTicketManagement.Application.Features.TicketRequest.Queries.GetTicketRequestDetails;

public class GetTicketRequestDetailQuery : IRequest<TicketRequestDetailsDto>
{
    public int Id { get; set; }
}