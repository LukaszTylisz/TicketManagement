using AutoMapper;
using FootballTicketManagement.Application.Contracts.Persistance;
using FootballTicketManagement.Application.Exceptions;
using MediatR;

namespace FootballTicketManagement.Application.Features.TicketAllocation.Queries.GetTitcketAllocationsDetails;

public class GetTicketAllocationsDetailsHandler : IRequestHandler<GetTicketAllocationsDetailsQuery, TicketAllocationsDetailsDto>
{
    private readonly IMapper _mapper;
    private readonly ITicketAllocationRepository _ticketAllocationRepository;

    public GetTicketAllocationsDetailsHandler(IMapper mapper, ITicketAllocationRepository ticketAllocationRepository)
    {
        _mapper = mapper;
        _ticketAllocationRepository = ticketAllocationRepository;
    }
    public async Task<TicketAllocationsDetailsDto> Handle(GetTicketAllocationsDetailsQuery request, CancellationToken cancellationToken)
    {
        var ticketAllocation = await _ticketAllocationRepository.GetTicketAllocationDetails(request.Id);

        _ = ticketAllocation ?? throw new NotFoundException(nameof(ticketAllocation), request.Id);
        
        var allocation = _mapper.Map<TicketAllocationsDetailsDto>(ticketAllocation);

        return allocation;
    }
}