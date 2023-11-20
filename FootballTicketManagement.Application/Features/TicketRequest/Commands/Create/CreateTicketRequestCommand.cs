using FootballTicketManagement.Application.Features.TicketRequest.Shared;
using MediatR;

namespace FootballTicketManagement.Application.Features.TicketRequest.Commands.Create;

public class CreateTicketRequestCommand : BaseTicketRequest, IRequest<Unit>
{
    public string RequestComments { get; set; } = string.Empty;
}