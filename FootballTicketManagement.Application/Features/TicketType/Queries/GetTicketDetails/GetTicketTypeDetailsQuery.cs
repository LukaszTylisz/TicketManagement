using MediatR;

namespace FootballTicketManagement.Application.Features.TicketType.Queries.GetTicketDetails;

public record GetTicketTypeDetailsQuery(int id) : IRequest<TicketTypeDetailsDto>;