using AutoMapper;
using FootballTicketManagement.Application.Contracts.Persistance;
using FootballTicketManagement.Application.Exceptions;
using MediatR;

namespace FootballTicketManagement.Application.Features.TicketRequest.Commands.Change;

public class ChangeTicketRequestResolvedHandler : IRequestHandler<ChangeTicketRequestResolvedCommand, Unit>
{
    private readonly ITicketTypeRepository _ticketTypeRepository;
    private readonly ITicketAllocationRepository _ticketAllocationRepository;
    private readonly ITicketRequestRepository _ticketRequestRepository;
    private readonly IMapper _mapper;

    public ChangeTicketRequestResolvedHandler(ITicketTypeRepository ticketTypeRepository,
        ITicketAllocationRepository ticketAllocationRepository, ITicketRequestRepository ticketRequestRepository, IMapper mapper)
    {
        _ticketTypeRepository = ticketTypeRepository;
        _ticketAllocationRepository = ticketAllocationRepository;
        _ticketRequestRepository = ticketRequestRepository;
        _mapper = mapper;
    }

    public async Task<Unit> Handle(ChangeTicketRequestResolvedCommand request, CancellationToken cancellationToken)
    {
        var ticketRequest = await _ticketRequestRepository.GetByIdAsync(request.Id);
        
        if (ticketRequest is null)
            throw new NotFoundException(nameof(Domain.TicketRequest), request.Id);

        ticketRequest.Resolved = request.Resolved;
        await _ticketRequestRepository.UpdateAsync(ticketRequest);

        return Unit.Value;
        // Employee allocation && emailsending
    }
}