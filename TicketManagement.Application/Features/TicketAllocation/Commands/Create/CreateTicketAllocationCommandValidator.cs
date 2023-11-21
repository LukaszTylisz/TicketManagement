using FluentValidation;
using TicketManagement.Application.Contracts.Persistance;

namespace TicketManagement.Application.Features.TicketAllocation.Commands.Create;

public class CreateTicketAllocationCommandValidator : AbstractValidator<CreateTicketAllocationCommand>
{
    private readonly ITicketTypeRepository _ticketTypeRepository;

    public CreateTicketAllocationCommandValidator(ITicketTypeRepository ticketTypeRepository)
    {
        _ticketTypeRepository = ticketTypeRepository;

        RuleFor(t => t.TicketTypeId)
            .GreaterThan(0)
            .MustAsync(TicketTypeMustExist)
            .WithMessage("{PropertyName} does not exist");
    }

    private async Task<bool> TicketTypeMustExist(int id, CancellationToken cancellationToken)
    {
        var ticketType = await _ticketTypeRepository.GetByIdAsync(id);
        return true;
    }
}