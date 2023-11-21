using FluentValidation;
using TicketManagement.Application.Features.TicketRequest.Shared;
using TicketManagement.Application.Contracts.Persistance;

namespace TicketManagement.Application.Features.TicketRequest.Commands.Update;

public class UpdateTicketRequestCommandValidator : AbstractValidator<UpdateTicketRequestCommand>
{
    private readonly ITicketTypeRepository _ticketTypeRepository;

    public UpdateTicketRequestCommandValidator(ITicketTypeRepository ticketTypeRepository)
    {
        _ticketTypeRepository = ticketTypeRepository;

        RuleFor(p => p.StartDate)
            .LessThan(p => p.EndDate).WithMessage("{PropertyName} must be before {ComparisonValue}");

        RuleFor(p => p.EndDate)
            .GreaterThan(p => p.StartDate).WithMessage("{PropertyName} must be after {ComparisonValue}");

        RuleFor(p => p.TicketTypeId)
            .GreaterThan(0)
            .MustAsync(TicketTypeMustExist)
            .WithMessage("{PropertyName} does not exist.");
    }

    private async Task<bool> TicketTypeMustExist(int id, CancellationToken cancellationToken)
    {
        var ticketType = await _ticketTypeRepository.GetByIdAsync(id);
        return ticketType != null;
    }
}