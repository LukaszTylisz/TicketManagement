using MediatR;
using TicketManagement.Application.Features.TicketRequest.Shared;

namespace TicketManagement.Application.Features.TicketRequest.Commands.Update;

public class UpdateTicketRequestCommand : BaseTicketRequest, IRequest<Unit>
{
     public int Id { get; set; }
     public string RequestComments { get; set; } = string.Empty;
     public bool Cancelled { get; set; }
}