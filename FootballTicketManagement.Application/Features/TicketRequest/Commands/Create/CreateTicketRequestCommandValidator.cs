using FluentValidation;
using FootballTicketManagement.Application.Contracts.Persistance;
using FootballTicketManagement.Application.Features.TicketRequest.Shared;

namespace FootballTicketManagement.Application.Features.TicketRequest.Commands.Create;

public class CreateTicketRequestCommandValidator : AbstractValidator<CreateTicketRequestCommand>
{
    private readonly ITicketTypeRepository _ticketTypeRepository;

    public CreateTicketRequestCommandValidator(ITicketTypeRepository ticketTypeRepository)
    {
        _ticketTypeRepository = ticketTypeRepository;
        Include(new BaseTicketRequestValidator(_ticketTypeRepository));
    }
}