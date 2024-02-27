using AutoMapper;
using MediatR;
using TicketManagement.Application.Contracts.Logging;
using TicketManagement.Application.Contracts.Persistence;

namespace TicketManagement.Application.Features.TicketType.Queries.GetAllTickets;

public class GetTicketTypeQueryHandler(
    IMapper mapper,
    ITicketTypeRepository ticketTypeRepository,
    IAppLogger<GetTicketTypeQueryHandler> logger)
    : IRequestHandler<GetTicketTypeQuery, List<TicketTypeDto>>
{
    public async Task<List<TicketTypeDto>> Handle(GetTicketTypeQuery request, CancellationToken cancellationToken)
    {
        var ticketTypes = await ticketTypeRepository.GetAsync();

        var data = mapper.Map<List<TicketTypeDto>>(ticketTypes);

        logger.LogInformation("Ticket types were retreived successfully");

        return data;
    }
}