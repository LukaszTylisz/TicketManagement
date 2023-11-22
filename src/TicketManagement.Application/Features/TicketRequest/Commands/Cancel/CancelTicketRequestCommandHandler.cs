using MediatR;
using TicketManagement.Application.Contracts.Email;
using TicketManagement.Application.Contracts.Logging;
using TicketManagement.Application.Contracts.Persistance;
using TicketManagement.Application.Exceptions;
using TicketManagement.Application.Models.Email;

namespace TicketManagement.Application.Features.TicketRequest.Commands.Cancel;

public class CancelTicketRequestCommandHandler : IRequestHandler<CancelTicketRequestCommand, Unit>
{
    private readonly ITicketRequestRepository _ticketRequestRepository;
    private readonly ITicketAllocationRepository _ticketAllocationRepository;
    private readonly IEmailSender _emailSender;
    private readonly IAppLoger<CancelTicketRequestCommandHandler> _appLoger;

    public CancelTicketRequestCommandHandler(ITicketRequestRepository ticketRequestRepository,
        ITicketAllocationRepository ticketAllocationRepository, IEmailSender emailSender,
        IAppLoger<CancelTicketRequestCommandHandler> appLoger)
    {
        _ticketRequestRepository = ticketRequestRepository;
        _ticketAllocationRepository = ticketAllocationRepository;
        _emailSender = emailSender;
        _appLoger = appLoger;
    }

    public async Task<Unit> Handle(CancelTicketRequestCommand request, CancellationToken cancellationToken)
    {
        var ticketRequest = await _ticketRequestRepository.GetByIdAsync(request.Id);

        if (ticketRequest is null)
            throw new NotFoundException(nameof(Domain.TicketRequest), request.Id);

        ticketRequest.Cancelled = true;
        await _ticketRequestRepository.UpdateAsync(ticketRequest);

        if(ticketRequest.Resolved == true)
        {
            int dayRequested = (int)(ticketRequest.EndDate - ticketRequest.StartDate).TotalDays;
            var allocation =
                await _ticketAllocationRepository.GetUserAllocations(ticketRequest.RequestingClientId,
                    ticketRequest.TicketTypeId);
            allocation.NumberOfDays += dayRequested;

            await _ticketAllocationRepository.UpdateAsync(allocation);
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

            await _emailSender.SendEmail(email);
        }
        catch (Exception ex)
        {
            _appLoger.LogWarning(ex.Message);
        }

        return Unit.Value;
    }
}