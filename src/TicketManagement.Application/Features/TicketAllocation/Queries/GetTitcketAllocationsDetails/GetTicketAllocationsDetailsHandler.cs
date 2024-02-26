using AutoMapper;
using MediatR;
using TicketManagement.Application.Contracts.Persistence;
using TicketManagement.Application.Exceptions;

namespace TicketManagement.Application.Features.TicketAllocation.Queries.GetTitcketAllocationsDetails;

public class GetTicketAllocationsDetailsHandler(IMapper mapper, ITicketAllocationRepository ticketAllocationRepository)
    : IRequestHandler<GetTicketAllocationsDetailsQuery, TicketAllocationsDetailsDto>
{
    public async Task<TicketAllocationsDetailsDto> Handle(GetTicketAllocationsDetailsQuery request, CancellationToken cancellationToken)
    {
        var ticketAllocation = await ticketAllocationRepository.GetTicketAllocationDetails(request.Id);

        _ = ticketAllocation ?? throw new NotFoundException(nameof(ticketAllocation), request.Id);
        
        var allocation = mapper.Map<TicketAllocationsDetailsDto>(ticketAllocation);

        return allocation;
    }
}