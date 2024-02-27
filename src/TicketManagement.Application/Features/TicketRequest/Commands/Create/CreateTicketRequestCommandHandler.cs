using AutoMapper;
using MediatR;
using TicketManagement.Application.Contracts.Email;
using TicketManagement.Application.Contracts.Identity;
using TicketManagement.Application.Contracts.Logging;
using TicketManagement.Application.Contracts.Persistence;
using TicketManagement.Application.Exceptions;
using TicketManagement.Application.Models.Email;

namespace TicketManagement.Application.Features.TicketRequest.Commands.Create;

public class CreateTicketRequestCommandHandler(
    IMapper mapper,
    ITicketTypeRepository ticketTypeRepository,
    ITicketRequestRepository ticketRequestRepository,
    ITicketAllocationRepository ticketAllocationRepository,
    IEmailSender emailSender,
    IUserService userService,
    IAppLogger<CreateTicketRequestCommandHandler> appLoger)
    : IRequestHandler<CreateTicketRequestCommand, Unit>
{
    public async Task<Unit> Handle(CreateTicketRequestCommand request, CancellationToken cancellationToken)
    {
        var validator = new CreateTicketRequestCommandValidator(ticketTypeRepository);
        var validationResult = await validator.ValidateAsync(request);

        if (validationResult.Errors.Any())
            throw new BadRequestException("Invalid ticket Request", validationResult);

        var clientId = userService.UserId;

        var allocation = await ticketAllocationRepository.GetUserAllocations(clientId, request.TicketTypeId);

        if (allocation is null)
        {
            validationResult.Errors.Add(new FluentValidation.Results.ValidationFailure(nameof(request.TicketTypeId),
                "You do not have any allocations for this ticket type."));
            throw new BadRequestException("Invalid Ticket Request", validationResult);
        }

        int daysRequested = (int)(request.EndDate - request.StartDate).TotalDays;
        if (daysRequested > allocation.NumberOfDays)
        {
            validationResult.Errors.Add(new FluentValidation.Results.ValidationFailure(
                nameof(request.EndDate), "You do not have enough days for this request"));
            throw new BadRequestException("Invalid Ticket Request", validationResult);
        }

        var ticketRequest = mapper.Map<Domain.TicketRequest>(request);
        ticketRequest.RequestingClientId = clientId;
        ticketRequest.DateRequested = DateTime.Now;
        await ticketRequestRepository.CreateAsync(ticketRequest);

        try
        {
            await emailSender.SendEmail(new EmailMessage
            {
                To = string.Empty,
                Body = $"Your ticket request for {request.StartDate:D} to {request.EndDate:D} " +
                       $"has been submitted successfully.",
                Subject = "Ticket Request Submitted"
            });
        }
        catch (Exception ex)
        {
            appLoger.LogWarning(ex.Message);
        }

        return Unit.Value;
    }
}