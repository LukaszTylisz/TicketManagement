using AutoMapper;
using MediatR;
using TicketManagement.Application.Contracts.Persistence;

namespace TicketManagement.Application.Features.TicketAllocation.Queries.GetTicketAllocations;

public class GetTicketTypeListHandler : IRequestHandler<GetTicketTypeListQuery, List<TicketAllocationDto>>
{
    private readonly IMapper _mapper;
    private readonly ITicketAllocationRepository _ticketAllocationRepository;

    public GetTicketTypeListHandler(IMapper mapper, ITicketAllocationRepository ticketAllocationRepository)
    {
        _mapper = mapper;
        _ticketAllocationRepository = ticketAllocationRepository;
    }
    
    public async Task<List<TicketAllocationDto>> Handle(GetTicketTypeListQuery request, CancellationToken cancellationToken)
    {
        // TO DO 
        // - Get records for specific user
        // - Get allocations per client
        
        var ticketAllocations = await _ticketAllocationRepository.GetTicketAllocationWithDetails();
        var allocations = _mapper.Map<List<TicketAllocationDto>>(ticketAllocations);

        return allocations;
    }
}