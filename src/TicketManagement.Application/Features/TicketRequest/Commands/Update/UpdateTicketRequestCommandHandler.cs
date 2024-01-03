using AutoMapper;
using MediatR;
using TicketManagement.Application.Contracts.Email;
using TicketManagement.Application.Contracts.Logging;
using TicketManagement.Application.Contracts.Persistance;
using TicketManagement.Application.Exceptions;
using TicketManagement.Application.Models.Email;

namespace TicketManagement.Application.Features.TicketRequest.Commands.Update;

public class UpdateTicketRequestCommandHandler : IRequestHandler<UpdateTicketRequestCommand, Unit>
{
    private readonly ITicketRequestRepository _ticketRequestRepository;
    private readonly ITicketTypeRepository _ticketTypeRepository;
    private readonly IMapper _mapper;
    private readonly IEmailSender _emailSender;
    private readonly IAppLogger<UpdateTicketRequestCommand> _appLoger;

    public UpdateTicketRequestCommandHandler(ITicketRequestRepository ticketRequestRepository,
        ITicketTypeRepository ticketTypeRepository, IMapper mapper, IEmailSender emailSender,
        IAppLogger<UpdateTicketRequestCommand> appLoger)
    {
        _ticketRequestRepository = ticketRequestRepository;
        _ticketTypeRepository = ticketTypeRepository;
        _mapper = mapper;
        this._emailSender = emailSender;
        this._appLoger = appLoger;
    }

    public async Task<Unit> Handle(UpdateTicketRequestCommand request, CancellationToken cancellationToken)
    {
        var ticketRequest = await _ticketRequestRepository.GetByIdAsync(request.Id);

        _ = ticketRequest ?? throw new NotFoundException(nameof(Domain.TicketRequest), request.Id);

        var validator = new UpdateTicketRequestCommandValidator(_ticketTypeRepository, _ticketRequestRepository);
        var validatorResult = await validator.ValidateAsync(request);
        
        if (validatorResult.Errors.Any())
            throw new BadRequestException("Invalid Ticket Request", validatorResult);

        _mapper.Map(request, ticketRequest);

        await _ticketRequestRepository.UpdateAsync(ticketRequest);
        
        try
        {
           
            var email = new EmailMessage
            {
                To = string.Empty,
                Body = $"Your ticket request for {request.StartDate:D} to {request.EndDate:D} " +
                       $"has been updated successfully.",
                Subject = "Ticket Request Updated"
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