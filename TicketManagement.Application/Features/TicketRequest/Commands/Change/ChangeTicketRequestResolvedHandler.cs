using AutoMapper;
using MediatR;
using TicketManagement.Application.Contracts.Email;
using TicketManagement.Application.Contracts.Persistance;
using TicketManagement.Application.Exceptions;

namespace TicketManagement.Application.Features.TicketRequest.Commands.Change;

public class ChangeTicketRequestResolvedHandler : IRequestHandler<ChangeTicketRequestResolvedCommand, Unit>
{
    private readonly ITicketTypeRepository _ticketTypeRepository;
    private readonly ITicketAllocationRepository _ticketAllocationRepository;
    private readonly ITicketRequestRepository _ticketRequestRepository;
    private readonly IMapper _mapper;
    private readonly IEmailSender _emailSender;

    public ChangeTicketRequestResolvedHandler(ITicketTypeRepository ticketTypeRepository,
        ITicketAllocationRepository ticketAllocationRepository, ITicketRequestRepository ticketRequestRepository,
        IMapper mapper, IEmailSender emailSender)
    {
        _ticketTypeRepository = ticketTypeRepository;
        _ticketAllocationRepository = ticketAllocationRepository;
        _ticketRequestRepository = ticketRequestRepository;
        _mapper = mapper;
        _emailSender = emailSender;
    }

    public async Task<Unit> Handle(ChangeTicketRequestResolvedCommand request, CancellationToken cancellationToken)
    {
        var ticketRequest = await _ticketRequestRepository.GetByIdAsync(request.Id);

        if (ticketRequest is null)
            throw new NotFoundException(nameof(Domain.TicketRequest), request.Id);

        ticketRequest.Resolved = request.Resolved;
        await _ticketRequestRepository.UpdateAsync(ticketRequest);

        return Unit.Value;
    }
}