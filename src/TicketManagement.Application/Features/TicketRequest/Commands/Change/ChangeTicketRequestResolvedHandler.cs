using AutoMapper;
using MediatR;
using TicketManagement.Application.Contracts.Email;
using TicketManagement.Application.Contracts.Logging;
using TicketManagement.Application.Contracts.Persistence;
using TicketManagement.Application.Exceptions;
using TicketManagement.Application.Models.Email;

namespace TicketManagement.Application.Features.TicketRequest.Commands.Change;

public class ChangeTicketRequestResolvedHandler(
    ITicketTypeRepository ticketTypeRepository,
    ITicketAllocationRepository ticketAllocationRepository,
    ITicketRequestRepository ticketRequestRepository,
    IMapper mapper,
    IEmailSender emailSender,
    IAppLogger<ChangeTicketRequestResolvedHandler> appLoger)
    : IRequestHandler<ChangeTicketRequestResolvedCommand, Unit>
{
    private readonly ITicketTypeRepository _ticketTypeRepository = ticketTypeRepository;
    private readonly IMapper _mapper = mapper;

    public async Task<Unit> Handle(ChangeTicketRequestResolvedCommand request, CancellationToken cancellationToken)
    {
        var ticketRequest = await ticketRequestRepository.GetByIdAsync(request.Id);

        if (ticketRequest is null)
            throw new NotFoundException(nameof(Domain.TicketRequest), request.Id);

        ticketRequest.Resolved = request.Resolved;
        await ticketRequestRepository.UpdateAsync(ticketRequest);
        
        if (request.Resolved)
        {
            int dayRequested = (int)(ticketRequest.EndDate - ticketRequest.StartDate).TotalDays;
            var allocation =
                await ticketAllocationRepository.GetUserAllocations(ticketRequest.RequestingClientId,
                    ticketRequest.TicketTypeId);
            allocation.NumberOfDays += dayRequested;

            await ticketAllocationRepository.UpdateAsync(allocation);
        }

        try
        {
            var email = new EmailMessage
            {
                To = string.Empty,
                Body = $"The resolved status for your ticket request for {ticketRequest.StartDate:D} to {ticketRequest.EndDate:D} has been updated.",
                Subject = "Ticket Request Approval Status Updated"
            };

            await emailSender.SendEmail(email);
        }
        catch (Exception ex)
        {
            appLoger.LogWarning(ex.Message);
        }

        return Unit.Value;
    }
}