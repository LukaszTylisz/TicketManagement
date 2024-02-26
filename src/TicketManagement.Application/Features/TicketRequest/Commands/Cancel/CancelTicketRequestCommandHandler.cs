using MediatR;
using TicketManagement.Application.Contracts.Email;
using TicketManagement.Application.Contracts.Logging;
using TicketManagement.Application.Contracts.Persistence;
using TicketManagement.Application.Exceptions;
using TicketManagement.Application.Models.Email;

namespace TicketManagement.Application.Features.TicketRequest.Commands.Cancel;

public class CancelTicketRequestCommandHandler(
    ITicketRequestRepository ticketRequestRepository,
    ITicketAllocationRepository ticketAllocationRepository,
    IEmailSender emailSender,
    IAppLogger<CancelTicketRequestCommandHandler> appLoger)
    : IRequestHandler<CancelTicketRequestCommand, Unit>
{
    public async Task<Unit> Handle(CancelTicketRequestCommand request, CancellationToken cancellationToken)
    {
        var ticketRequest = await ticketRequestRepository.GetByIdAsync(request.Id);

        if (ticketRequest is null)
            throw new NotFoundException(nameof(Domain.TicketRequest), request.Id);

        ticketRequest.Cancelled = true;
        await ticketRequestRepository.UpdateAsync(ticketRequest);

        if(ticketRequest.Resolved == true)
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
                Body =
                    $"Your ticket request for {ticketRequest.StartDate:D} to {ticketRequest.EndDate:D} has been cancelled successfully.",
                Subject = "Ticket Request Cancelled"
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