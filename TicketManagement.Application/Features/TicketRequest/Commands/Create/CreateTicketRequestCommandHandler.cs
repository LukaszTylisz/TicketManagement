using AutoMapper;
using MediatR;
using TicketManagement.Application.Contracts.Email;
using TicketManagement.Application.Contracts.Identity;
using TicketManagement.Application.Contracts.Persistance;
using TicketManagement.Application.Exceptions;

namespace TicketManagement.Application.Features.TicketRequest.Commands.Create;

public class CreateTicketRequestCommandHandler : IRequestHandler<CreateTicketRequestCommand, Unit>
{
    private readonly IMapper _mapper;
    private readonly ITicketTypeRepository _ticketTypeRepository;
    private readonly ITicketRequestRepository _ticketRequestRepository;
    private readonly ITicketAllocationRepository _ticketAllocationRepository;
    private readonly IEmailSender _emailSender;
    private readonly IUserService _userService;

    public CreateTicketRequestCommandHandler(IMapper mapper, ITicketTypeRepository ticketTypeRepository,
        ITicketRequestRepository ticketRequestRepository, ITicketAllocationRepository ticketAllocationRepository,
        IEmailSender emailSender, IUserService userService)
    {
        _mapper = mapper;
        _ticketTypeRepository = ticketTypeRepository;
        _ticketRequestRepository = ticketRequestRepository;
        _ticketAllocationRepository = ticketAllocationRepository;
        _emailSender = emailSender;
        _userService = userService;
    }

    public async Task<Unit> Handle(CreateTicketRequestCommand request, CancellationToken cancellationToken)
    {
        var validator = new CreateTicketRequestCommandValidator(_ticketTypeRepository);
        var validationResult = await validator.ValidateAsync(request);

        if (validationResult.Errors.Any())
            throw new BadRequestException("Invalid Leave Request", validationResult);

        var clientId = _userService.UserId;

        var allocation = await _ticketAllocationRepository.GetUserAllocations(clientId, request.TicketTypeId);
        
        if (allocation is null)
        {
            validationResult.Errors.Add(new FluentValidation.Results.ValidationFailure(nameof(request.TicketTypeId),
                "You do not have any allocations for this ticket type."));
            throw new BadRequestException("Invalid Leave Request", validationResult);
        }
        
        int daysRequested = (int)(request.EndDate - request.StartDate).TotalDays;
        if (daysRequested > allocation.NumberOfDays)
        {
            validationResult.Errors.Add(new FluentValidation.Results.ValidationFailure(
                nameof(request.EndDate), "You do not have enough days for this request"));
            throw new BadRequestException("Invalid Ticket Request", validationResult);
        }

        // We nedd Employee - will be added in future as Identity
        return Unit.Value;
    }
}