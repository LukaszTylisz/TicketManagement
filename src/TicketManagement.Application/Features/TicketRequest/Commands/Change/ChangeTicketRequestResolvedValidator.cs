using FluentValidation;

namespace TicketManagement.Application.Features.TicketRequest.Commands.Change;

public class ChangeTicketRequestResolvedValidator : AbstractValidator<ChangeTicketRequestResolvedCommand>
{
    public ChangeTicketRequestResolvedValidator()
    {
        RuleFor(p => p.Resolved)
            .NotNull()
            .WithMessage("Resolved status cannot be null");
    }
}