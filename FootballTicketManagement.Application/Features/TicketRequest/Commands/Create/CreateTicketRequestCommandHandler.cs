using AutoMapper;
using FootballTicketManagement.Application.Contracts.Persistance;
using FootballTicketManagement.Application.Exceptions;
using MediatR;

namespace FootballTicketManagement.Application.Features.TicketRequest.Commands.Create;

public class CreateTicketRequestCommandHandler : IRequestHandler<CreateTicketRequestCommand, Unit>
{
    private readonly IMapper _mapper;
    private readonly ITicketTypeRepository _ticketTypeRepository;
    private readonly ITicketRequestRepository _ticketRequestRepository;
    private readonly ITicketAllocationRepository _ticketAllocationRepository;

    public CreateTicketRequestCommandHandler(IMapper mapper, ITicketTypeRepository ticketTypeRepository,
        ITicketRequestRepository ticketRequestRepository, ITicketAllocationRepository ticketAllocationRepository)
    {
        _mapper = mapper;
        _ticketTypeRepository = ticketTypeRepository;
        _ticketRequestRepository = ticketRequestRepository;
        _ticketAllocationRepository = ticketAllocationRepository;
    }

    public async Task<Unit> Handle(CreateTicketRequestCommand request, CancellationToken cancellationToken)
    {
        var validator = new CreateTicketRequestCommandValidator(_ticketTypeRepository);
        var validationResult = await validator.ValidateAsync(request);
        
        if (validationResult.Errors.Any())
            throw new BadRequestException("Invalid Leave Request", validationResult);
        
        // We nedd Employee - will be added in future as Identity
        return Unit.Value;
    }
}