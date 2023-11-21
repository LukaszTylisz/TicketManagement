using MediatR;

namespace TicketManagement.Application.Features.TicketType.Queries.GetTicketDetails;

public record GetTicketTypeDetailsQuery(int id) : IRequest<TicketTypeDetailsDto>;