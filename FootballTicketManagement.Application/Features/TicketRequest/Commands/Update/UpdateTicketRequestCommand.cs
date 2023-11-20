using FootballTicketManagement.Application.Features.TicketRequest.Shared;
using MediatR;

namespace FootballTicketManagement.Application.Features.TicketRequest.Commands.Update;

public class UpdateTicketRequestCommand : BaseTicketRequest, IRequest<Unit>
{
     public int Id { get; set; }
     public string RequestComments { get; set; } = string.Empty;
     public bool Cancelled { get; set; }
}