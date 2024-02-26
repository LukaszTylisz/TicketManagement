using AutoMapper;
using MediatR;
using TicketManagement.Application.Contracts.Persistence;
using TicketManagement.Application.Exceptions;

namespace TicketManagement.Application.Features.TicketAllocation.Commands.Update;

public class UpdateTicketAllocationCommandHandler(
    IMapper mapper,
    ITicketTypeRepository ticketTypeRepository,
    ITicketAllocationRepository ticketAllocationRepository)
    : IRequestHandler<UpdateTicketAllocationCommand, Unit>
{
    public async Task<Unit> Handle(UpdateTicketAllocationCommand request, CancellationToken cancellationToken)
    {
        var validator = new UpdateTicketAllocationDtoValidator(ticketTypeRepository, ticketAllocationRepository);
        var validationResult = await validator.ValidateAsync(request);
        
        if (validationResult.Errors.Any())
            throw new BadRequestException("Invalid Ticket Allocation", validationResult);

        var ticketAllocation = await ticketAllocationRepository.GetByIdAsync(request.Id);

        _ = ticketAllocation ?? throw new NotFoundException(nameof(Domain.TicketAllocation), request.Id);

        mapper.Map(request, ticketAllocation);

        await ticketAllocationRepository.UpdateAsync(ticketAllocation);
        return Unit.Value;
    }
}