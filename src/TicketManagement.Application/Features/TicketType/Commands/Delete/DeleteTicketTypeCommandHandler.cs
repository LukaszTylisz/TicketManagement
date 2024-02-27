using MediatR;
using TicketManagement.Application.Contracts.Persistence;
using TicketManagement.Application.Exceptions;

namespace TicketManagement.Application.Features.TicketType.Commands.Delete;

public class DeleteTicketTypeCommandHandler(ITicketTypeRepository ticketTypeRepository)
    : IRequestHandler<DeleteTicketTypeCommand, Unit>
{
    public async Task<Unit> Handle(DeleteTicketTypeCommand request, CancellationToken cancellationToken)
    {
        // retrieve domain entity project
        var ticketTypeToDelete = await ticketTypeRepository.GetByIdAsync(request.Id) ??
                                 throw new NotFoundException(nameof(TicketType), request.Id);
        // remove from database
        await ticketTypeRepository.DeleteAsync(ticketTypeToDelete);

        return Unit.Value;
    }
}