using AutoMapper;
using FootballTicketManagement.Application.Contracts.Persistance;
using FootballTicketManagement.Application.Exceptions;
using MediatR;

namespace FootballTicketManagement.Application.Features.TicketAllocation.Queries.GetTitcketAllocationDetails;

public class GetTicketAllocationDetailsHandler : IRequestHandler<GetTicketAllocationDetailsQuery, TicketAllocationDetailsDto>
{
    private readonly IMapper _mapper;
    private readonly ITicketAllocationRepository _ticketAllocationRepository;

    public GetTicketAllocationDetailsHandler(IMapper mapper, ITicketAllocationRepository ticketAllocationRepository)
    {
        _mapper = mapper;
        _ticketAllocationRepository = ticketAllocationRepository;
    }
    public async Task<TicketAllocationDetailsDto> Handle(GetTicketAllocationDetailsQuery request, CancellationToken cancellationToken)
    {
        var ticketAllocation = await _ticketAllocationRepository.GetTicketAllocationDetails(request.Id);

        _ = ticketAllocation ?? throw new NotFoundException(nameof(ticketAllocation), request.Id);
        
        var allocation = _mapper.Map<TicketAllocationDetailsDto>(ticketAllocation);

        return allocation;
    }
}