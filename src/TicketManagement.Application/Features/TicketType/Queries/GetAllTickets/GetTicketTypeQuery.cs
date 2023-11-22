using MediatR;

namespace TicketManagement.Application.Features.TicketType.Queries.GetAllTickets;

public record GetTicketTypeQuery : IRequest<List<TicketTypeDto>>;