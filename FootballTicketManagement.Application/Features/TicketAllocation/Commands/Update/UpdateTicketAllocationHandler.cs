using AutoMapper;
using FootballTicketManagement.Application.Contracts.Persistance;
using FootballTicketManagement.Application.Exceptions;
using MediatR;

namespace FootballTicketManagement.Application.Features.TicketAllocation.Commands.Update;

public class UpdateTicketAllocationHandler : IRequestHandler<UpdateTicketAllocationCommand, Unit>
{
    private readonly IMapper _mapper;
    private readonly ITicketTypeRepository _ticketTypeRepository;
    private readonly ITicketAllocationRepository _ticketAllocationRepository;

    public UpdateTicketAllocationHandler(IMapper mapper, ITicketTypeRepository ticketTypeRepository,
        ITicketAllocationRepository ticketAllocationRepository)
    {
        _mapper = mapper;
        this._ticketTypeRepository = ticketTypeRepository;
        this._ticketAllocationRepository = ticketAllocationRepository;
    }

    public async Task<Unit> Handle(UpdateTicketAllocationCommand request, CancellationToken cancellationToken)
    {
        var validator = new UpdateTicketAllocationDtoValidator(_ticketTypeRepository, _ticketAllocationRepository);
        var validationResult = await validator.ValidateAsync(request);
        
        if (validationResult.Errors.Any())
            throw new BadRequestException("Invalid Ticket Allocation", validationResult);

        var ticketAllocation = await _ticketAllocationRepository.GetByIdAsync(request.Id);

        _ = ticketAllocation ?? throw new NotFoundException(nameof(Domain.TicketAllocation), request.Id);

        _mapper.Map(request, ticketAllocation);

        await _ticketAllocationRepository.UpdateAsync(ticketAllocation);
        return Unit.Value;
    }
}