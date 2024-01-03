using AutoMapper;
using MediatR;
using TicketManagement.Application.Contracts.Email;
using TicketManagement.Application.Contracts.Logging;
using TicketManagement.Application.Contracts.Persistance;
using TicketManagement.Application.Exceptions;
using TicketManagement.Application.Models.Email;

namespace TicketManagement.Application.Features.TicketRequest.Commands.Change;

public class ChangeTicketRequestResolvedHandler : IRequestHandler<ChangeTicketRequestResolvedCommand, Unit>
{
    private readonly ITicketTypeRepository _ticketTypeRepository;
    private readonly ITicketAllocationRepository _ticketAllocationRepository;
    private readonly ITicketRequestRepository _ticketRequestRepository;
    private readonly IMapper _mapper;
    private readonly IEmailSender _emailSender;
    private readonly IAppLogger<ChangeTicketRequestResolvedHandler> _appLoger;

    public ChangeTicketRequestResolvedHandler(ITicketTypeRepository ticketTypeRepository,
        ITicketAllocationRepository ticketAllocationRepository, ITicketRequestRepository ticketRequestRepository,
        IMapper mapper, IEmailSender emailSender, IAppLogger<ChangeTicketRequestResolvedHandler> appLoger)
    {
        _ticketTypeRepository = ticketTypeRepository;
        _ticketAllocationRepository = ticketAllocationRepository;
        _ticketRequestRepository = ticketRequestRepository;
        _mapper = mapper;
        _emailSender = emailSender;
        _appLoger = appLoger;
    }

    public async Task<Unit> Handle(ChangeTicketRequestResolvedCommand request, CancellationToken cancellationToken)
    {
        var ticketRequest = await _ticketRequestRepository.GetByIdAsync(request.Id);

        if (ticketRequest is null)
            throw new NotFoundException(nameof(Domain.TicketRequest), request.Id);

        ticketRequest.Resolved = request.Resolved;
        await _ticketRequestRepository.UpdateAsync(ticketRequest);
        
        if (request.Resolved)
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
                Body = $"The resolved status for your ticket request for {ticketRequest.StartDate:D} to {ticketRequest.EndDate:D} has been updated.",
                Subject = "Ticket Request Approval Status Updated"
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