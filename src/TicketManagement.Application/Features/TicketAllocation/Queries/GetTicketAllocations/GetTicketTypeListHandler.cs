using AutoMapper;
using MediatR;
using TicketManagement.Application.Contracts.Persistence;

namespace TicketManagement.Application.Features.TicketAllocation.Queries.GetTicketAllocations;

public class GetTicketTypeListHandler(IMapper mapper, ITicketAllocationRepository ticketAllocationRepository)
    : IRequestHandler<GetTicketTypeListQuery, List<TicketAllocationDto>>
{
    public async Task<List<TicketAllocationDto>> Handle(GetTicketTypeListQuery request, CancellationToken cancellationToken)
    {
        var ticketAllocations = await ticketAllocationRepository.GetTicketAllocationWithDetails();
        var allocations = mapper.Map<List<TicketAllocationDto>>(ticketAllocations);

        return allocations;
    }
}