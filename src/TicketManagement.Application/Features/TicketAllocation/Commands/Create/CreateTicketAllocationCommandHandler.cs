using AutoMapper;
using MediatR;
using TicketManagement.Application.Contracts.Identity;
using TicketManagement.Application.Contracts.Persistance;
using TicketManagement.Application.Exceptions;

namespace TicketManagement.Application.Features.TicketAllocation.Commands.Create;

public class CreateTicketAllocationCommandHandler : IRequestHandler<CreateTicketAllocationCommand, Unit>
{
    private readonly IMapper _mapper;
    private readonly ITicketAllocationRepository _ticketAllocationRepository;
    private readonly ITicketTypeRepository _ticketTypeRepository;
    private readonly IUserService _userService;

    public CreateTicketAllocationCommandHandler(IMapper mapper, ITicketAllocationRepository ticketAllocationRepository,
        ITicketTypeRepository ticketTypeRepository, IUserService userService)
    {
        _mapper = mapper;
        _ticketAllocationRepository = ticketAllocationRepository;
        _ticketTypeRepository = ticketTypeRepository;
        _userService = userService;
    }

    public async Task<Unit> Handle(CreateTicketAllocationCommand request, CancellationToken cancellationToken)
    {
        var validator = new CreateTicketAllocationCommandValidator(_ticketTypeRepository);
        var validationResult = await validator.ValidateAsync(request);

        if (validationResult.Errors.Any())
            throw new BadRequestException("Invalid Ticket Allocation Request", validationResult);

        // Get Ticket Type for Allocations
        var ticketType = await _ticketTypeRepository.GetByIdAsync(request.TicketTypeId);

        var clients = await _userService.GetClients();

        // Get Period
        var period = DateTime.Now.Year;

        // Assign Allocations IF an Allocation doesn't already exist for period and Ticket Type
        var allocations = new List<Domain.TicketAllocation>();
        foreach (var client in clients)
        {
            var allocationExists =
                await _ticketAllocationRepository.AllocationExists(client.Id, request.TicketTypeId, period);

            if (allocationExists == false)
            {
                allocations.Add(new Domain.TicketAllocation
                {
                    ClientId = client.Id,
                    TicketTypeId = ticketType.Id,
                    NumberOfDays = ticketType.DefaultDays,
                    Period = period
                });
            }
        }

        if (allocations.Any())
        {
            await _ticketAllocationRepository.AddAllocations(allocations);
        }
        
        return Unit.Value;
    }
}