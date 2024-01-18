using AutoMapper;
using MediatR;
using TicketManagement.Application.Contracts.Logging;
using TicketManagement.Application.Contracts.Persistence;

namespace TicketManagement.Application.Features.TicketType.Queries.GetAllTickets;

public class GetTicketTypeQueryHandler : IRequestHandler<GetTicketTypeQuery, List<TicketTypeDto>>
{
    private readonly IMapper _mapper;
    private readonly ITicketTypeRepository _ticketTypeRepository;
    private readonly IAppLogger<GetTicketTypeQueryHandler> _logger;

    public GetTicketTypeQueryHandler(IMapper mapper, ITicketTypeRepository ticketTypeRepository, IAppLogger<GetTicketTypeQueryHandler> logger)
    {
        _mapper = mapper;
        _ticketTypeRepository = ticketTypeRepository;
        _logger = logger;
    }
    public async Task<List<TicketTypeDto>> Handle(GetTicketTypeQuery request, CancellationToken cancellationToken)
    {
        var ticketTypes = await _ticketTypeRepository.GetAsync();
        
        var data = _mapper.Map<List<TicketTypeDto>>(ticketTypes);
        
        _logger.LogInformation("Ticket types were retreived successfully");

        return data;
    }
}