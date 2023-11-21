using MediatR;

namespace FootballTicketManagement.Application.Features.TicketRequest.Commands.Cancel;

public class CancelTicketRequestCommand : IRequest<Unit>
{
    public int Id { get; set; }
}