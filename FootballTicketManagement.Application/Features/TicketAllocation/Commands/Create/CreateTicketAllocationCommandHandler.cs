using AutoMapper;
using FootballTicketManagement.Application.Contracts.Persistance;
using FootballTicketManagement.Application.Exceptions;
using MediatR;

namespace FootballTicketManagement.Application.Features.TicketAllocation.Commands.Create;

public class CreateTicketAllocationCommandHandler : IRequestHandler<CreateTicketAllocationCommand, Unit>
{
    private readonly IMapper _mapper;
    private readonly ITicketAllocationRepository _ticketAllocationRepository;
    private readonly ITicketTypeRepository _ticketTypeRepository;

    public CreateTicketAllocationCommandHandler(IMapper mapper, ITicketAllocationRepository ticketAllocationRepository,
        ITicketTypeRepository ticketTypeRepository)
    {
        _mapper = mapper;
        _ticketAllocationRepository = ticketAllocationRepository;
        _ticketTypeRepository = ticketTypeRepository;
    }

    public async Task<Unit> Handle(CreateTicketAllocationCommand request, CancellationToken cancellationToken)
    {
        var validator = new CreateTicketAllocationCommandValidator(_ticketTypeRepository);
        var validationResult = await validator.ValidateAsync(request);
        
        if (validationResult.Errors.Any())
            throw new BadRequestException("Invalid Leave Allocation Request", validationResult);

        // Get Ticket Type for Allocations
        var ticketType = await _ticketTypeRepository.GetByIdAsync(request.TicketTypeId);
        
        // Get Period
        var period = DateTime.Now.Year;
        
        // Assign Allocations IF an Allocation doesn't already exist for period and Ticket Type
        var allocations = new List<Domain.TicketAllocation>();

        // TO DO - needed to create User Service where will Clients exsits to add for each client TicketAllocation
        //
        //
        
        return Unit.Value;
    }
}