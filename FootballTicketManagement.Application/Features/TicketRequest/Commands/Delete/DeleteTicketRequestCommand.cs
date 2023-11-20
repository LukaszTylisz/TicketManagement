using MediatR;

namespace FootballTicketManagement.Application.Features.TicketRequest.Commands.Delete;

public class DeleteTicketRequestCommand : IRequest
{
    public int Id { get; set; }
}