using MediatR;

namespace FootballTicketManagement.Application.Features.TicketType.Queries.GetAllTickets;

public record GetTicketTypeQuery : IRequest<List<TicketTypeDto>>;