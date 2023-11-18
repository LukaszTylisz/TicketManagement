using AutoMapper;
using FootballTicketManagement.Application.Contracts.Persistance;
using MediatR;

namespace FootballTicketManagement.Application.Features.TicketType.Queries.GetAllTickets;

public class GetTicketTypeQueryHandler : IRequestHandler<GetTicketTypeQuery, List<TicketTypeDto>>
{
    private readonly IMapper _mapper;
    private readonly ITicketTypeRepository _ticketTypeRepository;

    public GetTicketTypeQueryHandler(IMapper mapper, ITicketTypeRepository ticketTypeRepository)
    {
        _mapper = mapper;
        _ticketTypeRepository = ticketTypeRepository;
    }
    public async Task<List<TicketTypeDto>> Handle(GetTicketTypeQuery request, CancellationToken cancellationToken)
    {
        // Query to Database
        var ticketTypes = await _ticketTypeRepository.GetAsync();
        
        // Convert data objects to Dto object
        var data = _mapper.Map<List<TicketTypeDto>>(ticketTypes);

        return data;
    }
}