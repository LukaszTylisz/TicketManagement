using FluentValidation;
using FootballTicketManagement.Application.Contracts.Persistance;

namespace FootballTicketManagement.Application.Features.TicketType.Commands.Create;

public class CreateTicketTypeCommandValidator : AbstractValidator<CreateTicketTypeCommand>
{
    private readonly ITicketTypeRepository _ticketTypeRepository;

    public CreateTicketTypeCommandValidator(ITicketTypeRepository ticketTypeRepository)
    {

        RuleFor(p => p.Name)
            .NotEmpty().WithMessage("{PropertyName} is required")
            .NotNull()
            .MaximumLength(20).WithMessage("{PropertyName} must be fewer than 20 characters");

        RuleFor(p => p.DefaultResolutionTime)
            .LessThan(100).WithMessage("{PropertyName} cannot exceed 100 ")
            .GreaterThan(1).WithMessage("{PropertyName} cannot be less than 1");

        RuleFor(q => q)
            .MustAsync(TicketNameUnique)
            .WithMessage("Leave Type already exists");

        _ticketTypeRepository = ticketTypeRepository;
    }

    private Task<bool> TicketNameUnique(CreateTicketTypeCommand command, CancellationToken cancellationToken)
    {
        return _ticketTypeRepository.IsTicketUnique(command.Name);
    }
}