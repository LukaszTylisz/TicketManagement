using MediatR;

namespace FootballTicketManagement.Application.Features.TicketType.Commands.Update;

public class UpdateTicketTypeCommand : IRequest<Unit>
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public int DefaultResolutionTime { get; set; }
}