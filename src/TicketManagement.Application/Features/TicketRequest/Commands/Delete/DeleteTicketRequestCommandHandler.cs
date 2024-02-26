using MediatR;
using TicketManagement.Application.Contracts.Persistence;
using TicketManagement.Application.Exceptions;

namespace TicketManagement.Application.Features.TicketRequest.Commands.Delete;

public class DeleteTicketRequestCommandHandler(ITicketRequestRepository ticketRequestRepository)
    : IRequestHandler<DeleteTicketRequestCommand>
{
    public async Task Handle(DeleteTicketRequestCommand request, CancellationToken cancellationToken)
    {
        var ticketRequest = await ticketRequestRepository.GetByIdAsync(request.Id);

        if (ticketRequest == null)
            throw new NotFoundException(nameof(Domain.TicketRequest), request.Id);

        await ticketRequestRepository.DeleteAsync(ticketRequest);
    }
}