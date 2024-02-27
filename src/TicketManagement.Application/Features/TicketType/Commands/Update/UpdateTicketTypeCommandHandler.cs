using AutoMapper;
using FluentValidation;
using MediatR;
using TicketManagement.Application.Contracts.Logging;
using TicketManagement.Application.Contracts.Persistence;
using TicketManagement.Application.Exceptions;

namespace TicketManagement.Application.Features.TicketType.Commands.Update;

public class UpdateTicketTypeCommandHandler(
    IMapper mapper,
    ITicketTypeRepository ticketTypeRepository,
    IAppLogger<UpdateTicketTypeCommandHandler> loger)
    : IRequestHandler<UpdateTicketTypeCommand, Unit>
{
    public async Task<Unit> Handle(UpdateTicketTypeCommand request, CancellationToken cancellationToken)
    {
        var validator = new UpdateTicketTypeCommandValidator(ticketTypeRepository);
        var validationResult = await validator.ValidateAsync(request);

        if (validationResult.Errors.Any())
        {
            loger.LogWarning("Validation errors in update ticket for {0} - {1}", nameof(TicketType), request.Id);
            throw new BadRequestException("Invalid ticket type", validationResult);
        }

        var ticketTypeToUpdate = mapper.Map<Domain.TicketType>(request);

        await ticketTypeRepository.UpdateAsync(ticketTypeToUpdate);

        return Unit.Value;
    }
}