using FluentValidation;
using TicketManagement.Application.Contracts.Persistence;

namespace TicketManagement.Application.Features.TicketAllocation.Commands.Update;

public class UpdateTicketAllocationDtoValidator : AbstractValidator<UpdateTicketAllocationCommand>
{
    private readonly ITicketTypeRepository _ticketTypeRepository;
    private readonly ITicketAllocationRepository _ticketAllocationRepository;

    public UpdateTicketAllocationDtoValidator(ITicketTypeRepository ticketTypeRepository,
        ITicketAllocationRepository ticketAllocationRepository)
    {
        _ticketTypeRepository = ticketTypeRepository;
        this._ticketAllocationRepository = ticketAllocationRepository;
        
        RuleFor(t => t.NumberOfDays)
            .GreaterThan(0).WithMessage("{PropertyName} must greater than {ComparisonValue}");
        
        RuleFor(t => t.Period)
            .GreaterThanOrEqualTo(DateTime.Now.Year).WithMessage("{PropertyName} must greater than {ComparisonValue}");
        
        RuleFor(t => t.TicketTypeId)
            .GreaterThan(0)
            .MustAsync(TicketTypeMustExist)
            .WithMessage("{PropertyName} does not exist.");
        
        RuleFor(t => t.Id)
            .NotNull()
            .MustAsync(TicketAllocationMustExist)
            .WithMessage("{PropertyName} does not exist.");
    }

    private async Task<bool> TicketAllocationMustExist(int id, CancellationToken cancellationToken)
    {
        var ticketAllocation = await _ticketAllocationRepository.GetByIdAsync(id);
        return ticketAllocation != null;
    }

    private async Task<bool> TicketTypeMustExist(int id, CancellationToken cancellationToken)
    {
        var ticketType = await _ticketTypeRepository.GetByIdAsync(id);
        return ticketType != null;
    }
}