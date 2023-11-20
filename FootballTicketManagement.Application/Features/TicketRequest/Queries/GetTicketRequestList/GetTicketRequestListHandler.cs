using AutoMapper;
using FootballTicketManagement.Application.Contracts.Persistance;
using MediatR;

namespace FootballTicketManagement.Application.Features.TicketRequest.Queries.GetTicketRequestList;

public class GetTicketRequestListHandler : IRequestHandler<GetTicketRequestListQuery, List<TicketRequestListDto>>
{
    private readonly ITicketRequestRepository _ticketRequestRepository;
    private readonly IMapper _mapper;

    public GetTicketRequestListHandler(ITicketRequestRepository ticketRequestRepository, IMapper mapper)
    {
        _ticketRequestRepository = ticketRequestRepository;
        _mapper = mapper;
    }
    public async Task<List<TicketRequestListDto>> Handle(GetTicketRequestListQuery request, CancellationToken cancellationToken)
    {
        var ticketRequests = new List<Domain.TicketRequest>();
        var requests = new List<TicketRequestListDto>();
        
        // Employee is needed to implement it//
        
    }
}