using AutoMapper;
using MediatR;
using TicketManagement.Application.Contracts.Email;
using TicketManagement.Application.Contracts.Logging;
using TicketManagement.Application.Contracts.Persistence;
using TicketManagement.Application.Exceptions;
using TicketManagement.Application.Models.Email;

namespace TicketManagement.Application.Features.TicketRequest.Commands.Update;

public class UpdateTicketRequestCommandHandler(
    ITicketRequestRepository ticketRequestRepository,
    ITicketTypeRepository ticketTypeRepository,
    IMapper mapper,
    IEmailSender emailSender,
    IAppLogger<UpdateTicketRequestCommand> appLoger)
    : IRequestHandler<UpdateTicketRequestCommand, Unit>
{
    public async Task<Unit> Handle(UpdateTicketRequestCommand request, CancellationToken cancellationToken)
    {
        var ticketRequest = await ticketRequestRepository.GetByIdAsync(request.Id);

        _ = ticketRequest ?? throw new NotFoundException(nameof(Domain.TicketRequest), request.Id);

        var validator = new UpdateTicketRequestCommandValidator(ticketTypeRepository, ticketRequestRepository);
        var validatorResult = await validator.ValidateAsync(request);
        
        if (validatorResult.Errors.Any())
            throw new BadRequestException("Invalid Ticket Request", validatorResult);

        mapper.Map(request, ticketRequest);

        await ticketRequestRepository.UpdateAsync(ticketRequest);
        
        try
        {
           
            var email = new EmailMessage
            {
                To = string.Empty,
                Body = $"Your ticket request for {request.StartDate:D} to {request.EndDate:D} " +
                       $"has been updated successfully.",
                Subject = "Ticket Request Updated"
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