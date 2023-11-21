using MediatR;

namespace TicketManagement.Application.Features.TicketRequest.Commands.Cancel;

public class CancelTicketRequestCommand : IRequest<Unit>
{
    public int Id { get; set; }
}