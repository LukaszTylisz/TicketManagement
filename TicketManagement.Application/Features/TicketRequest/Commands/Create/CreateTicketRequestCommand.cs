using MediatR;
using TicketManagement.Application.Features.TicketRequest.Shared;

namespace TicketManagement.Application.Features.TicketRequest.Commands.Create;

public class CreateTicketRequestCommand : BaseTicketRequest, IRequest<Unit>
{
    public string RequestComments { get; set; } = string.Empty;
}