using FluentValidation;
using TicketManagement.Application.Contracts.Persistence;
using TicketManagement.Application.Features.TicketRequest.Shared;

namespace TicketManagement.Application.Features.TicketRequest.Commands.Create;

public class CreateTicketRequestCommandValidator : AbstractValidator<CreateTicketRequestCommand>
{
    private readonly ITicketTypeRepository _ticketTypeRepository;

    public CreateTicketRequestCommandValidator(ITicketTypeRepository ticketTypeRepository)
    {
        _ticketTypeRepository = ticketTypeRepository;
        Include(new BaseTicketRequestValidator(_ticketTypeRepository));
    }
}