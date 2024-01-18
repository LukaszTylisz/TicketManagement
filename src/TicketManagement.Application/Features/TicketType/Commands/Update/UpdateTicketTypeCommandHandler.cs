using AutoMapper;
using FluentValidation;
using MediatR;
using TicketManagement.Application.Contracts.Logging;
using TicketManagement.Application.Contracts.Persistence;
using TicketManagement.Application.Exceptions;

namespace TicketManagement.Application.Features.TicketType.Commands.Update;

public class UpdateTicketTypeCommandHandler : IRequestHandler<UpdateTicketTypeCommand, Unit>
{
    private readonly IMapper _mapper;
    private readonly ITicketTypeRepository _ticketTypeRepository;
    private readonly IAppLogger<UpdateTicketTypeCommandHandler> _logger;

    public UpdateTicketTypeCommandHandler(IMapper mapper, ITicketTypeRepository ticketTypeRepository, IAppLogger<UpdateTicketTypeCommandHandler> loger)
    {
        _mapper = mapper;
        _ticketTypeRepository = ticketTypeRepository;
        _logger = loger;
    }
    public async Task<Unit> Handle(UpdateTicketTypeCommand request, CancellationToken cancellationToken)
    {
        var validator = new UpdateTicketTypeCommandValidator(_ticketTypeRepository);
        var validationResult = await validator.ValidateAsync(request);
        
        if (validationResult.Errors.Any())
        {
            _logger.LogWarning("Validation errors in update ticket for {0} - {1}", nameof(TicketType), request.Id);
            throw new BadRequestException("Invalid ticket type", validationResult);
        }

        var ticketTypeToUpdate = _mapper.Map<Domain.TicketType>(request);

        await _ticketTypeRepository.UpdateAsync(ticketTypeToUpdate);
        
        return Unit.Value;
        
    }
}