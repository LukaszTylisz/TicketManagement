using FootballTicketManagement.Application.Contracts.Persistance;
using FootballTicketManagement.Application.Exceptions;
using MediatR;

namespace FootballTicketManagement.Application.Features.TicketRequest.Commands.Cancel;

public class CancelTicketRequestCommandHandler : IRequestHandler<CancelTicketRequestCommand, Unit>
{
    private readonly ITicketRequestRepository _ticketRequestRepository;
    private readonly ITicketAllocationRepository _ticketAllocationRepository;

    public CancelTicketRequestCommandHandler(ITicketRequestRepository ticketRequestRepository,
        ITicketAllocationRepository ticketAllocationRepository)
    {
        _ticketRequestRepository = ticketRequestRepository;
        _ticketAllocationRepository = ticketAllocationRepository;
    }

    public async Task<Unit> Handle(CancelTicketRequestCommand request, CancellationToken cancellationToken)
    {
        var ticketRequest = await _ticketRequestRepository.GetByIdAsync(request.Id);
        
        if (ticketRequest is null)
                        throw new NotFoundException(nameof(Domain.TicketRequest), request.Id);

        ticketRequest.Cancelled = true;
        await _ticketRequestRepository.UpdateAsync(ticketRequest);
        
        return Unit.Value;
        // EMployee needed and mail sending
    }
}