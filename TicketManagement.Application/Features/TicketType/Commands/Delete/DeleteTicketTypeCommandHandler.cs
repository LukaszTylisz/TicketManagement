using MediatR;
using TicketManagement.Application.Contracts.Persistance;
using TicketManagement.Application.Exceptions;

namespace TicketManagement.Application.Features.TicketType.Commands.Delete;

public class DeleteTicketTypeCommandHandler : IRequestHandler<DeleteTicketTypeCommand, Unit>
{
    private readonly ITicketTypeRepository _ticketTypeRepository;

    public DeleteTicketTypeCommandHandler(ITicketTypeRepository ticketTypeRepository) =>
        _ticketTypeRepository = ticketTypeRepository;
    
    public async Task<Unit> Handle(DeleteTicketTypeCommand request, CancellationToken cancellationToken)
    {
        // retrieve domain entity project
        var ticketTypeToDelete = await _ticketTypeRepository.GetByIdAsync(request.Id) ?? 
                                 throw new NotFoundException(nameof(TicketType), request.Id);
        // remove from database
        await _ticketTypeRepository.DeleteAsync(ticketTypeToDelete);

        return Unit.Value;
    }
}