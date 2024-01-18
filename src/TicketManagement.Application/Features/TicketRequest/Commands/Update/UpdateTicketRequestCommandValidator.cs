using FluentValidation;
using TicketManagement.Application.Features.TicketRequest.Shared;
using TicketManagement.Application.Contracts.Persistence;

namespace TicketManagement.Application.Features.TicketRequest.Commands.Update;

public class UpdateTicketRequestCommandValidator : AbstractValidator<UpdateTicketRequestCommand>
{
    private readonly ITicketTypeRepository _ticketTypeRepository;
    private readonly ITicketRequestRepository _ticketRequestRepository;

    public UpdateTicketRequestCommandValidator(ITicketTypeRepository ticketTypeRepository,
        ITicketRequestRepository ticketRequestRepository)
    {
        _ticketTypeRepository = ticketTypeRepository;
        _ticketRequestRepository = ticketRequestRepository;

        Include(new BaseTicketRequestValidator(_ticketTypeRepository));

        RuleFor(p => p.Id)
            .NotNull()
            .MustAsync(TicketRequestMustExist)
            .WithMessage("{PropertyName} must be present");
    }

    private async Task<bool> TicketRequestMustExist(int id, CancellationToken cancellationToken)
    {
        var ticketAllocation = await _ticketRequestRepository.GetByIdAsync(id);
        return ticketAllocation != null;
    }
}