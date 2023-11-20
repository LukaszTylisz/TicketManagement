using FluentValidation;
using FootballTicketManagement.Application.Contracts.Persistance;
using FootballTicketManagement.Application.Features.TicketRequest.Shared;

namespace FootballTicketManagement.Application.Features.TicketRequest.Commands.Update;

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