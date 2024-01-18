using FluentValidation;
using TicketManagement.Application.Contracts.Persistence;

namespace TicketManagement.Application.Features.TicketType.Commands.Update;

public class UpdateTicketTypeCommandValidator : AbstractValidator<UpdateTicketTypeCommand>
{
    private readonly ITicketTypeRepository _ticketTypeRepository;

    public UpdateTicketTypeCommandValidator(ITicketTypeRepository ticketTypeRepository)
    {
        RuleFor(p => p.Id)
            .NotNull()
            .MustAsync(TicketTypeTypeMustExist);

        RuleFor(p => p.Name)
            .NotEmpty().WithMessage("{PropertyName} is required")
            .NotNull()
            .MaximumLength(70).WithMessage("{PropertyName} must be fewer than 70 characters");

        RuleFor(p => p.DefaultDays)
            .LessThan(100).WithMessage("{PropertyName} cannot exceed 100")
            .GreaterThan(1).WithMessage("{PropertyName} cannot be less than 1");

        this._ticketTypeRepository = ticketTypeRepository;
    }

    private async Task<bool> TicketTypeTypeMustExist(int id, CancellationToken cancellationToken)
    {
        var ticketType = await _ticketTypeRepository.GetByIdAsync(id);
        return ticketType != null;
    }
}