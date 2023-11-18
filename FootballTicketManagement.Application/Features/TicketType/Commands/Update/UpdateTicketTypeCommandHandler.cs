using AutoMapper;
using FluentValidation;
using FootballTicketManagement.Application.Contracts.Persistance;
using FootballTicketManagement.Application.Exceptions;
using MediatR;

namespace FootballTicketManagement.Application.Features.TicketType.Commands.Update;

public class UpdateTicketTypeCommandHandler : IRequestHandler<UpdateTicketTypeCommand, Unit>
{
    private readonly IMapper _mapper;
    private readonly ITicketTypeRepository _ticketTypeRepository;

    public UpdateTicketTypeCommandHandler(IMapper mapper, ITicketTypeRepository ticketTypeRepository)
    {
        _mapper = mapper;
        _ticketTypeRepository = ticketTypeRepository;
    }
    public async Task<Unit> Handle(UpdateTicketTypeCommand request, CancellationToken cancellationToken)
    {
        var validator = new UpdateTicketTypeCommandValidator(_ticketTypeRepository);
        var validationResult = await validator.ValidateAsync(request);
        
        if (validationResult.Errors.Any())
        {
            throw new BadRequestException("Invalid Leave type", validationResult);
        }

        var ticketTypeToUpdate = _mapper.Map<Domain.TicketType>(request);

        await _ticketTypeRepository.UpdateAsync(ticketTypeToUpdate);
        
        return Unit.Value;
        
    }
}