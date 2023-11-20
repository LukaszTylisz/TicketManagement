using FootballTicketManagement.Application.Contracts.Persistance;
using FootballTicketManagement.Application.Exceptions;
using MediatR;

namespace FootballTicketManagement.Application.Features.TicketRequest.Commands.Delete;

public class DeleteTicketRequestCommandHandler : IRequestHandler<DeleteTicketRequestCommand>
{
    private readonly ITicketRequestRepository _ticketRequestRepository;

    public DeleteTicketRequestCommandHandler(ITicketRequestRepository ticketRequestRepository)
    {
        _ticketRequestRepository = ticketRequestRepository;
    }
    public async Task Handle(DeleteTicketRequestCommand request, CancellationToken cancellationToken)
    {
        var ticketRequest = await _ticketRequestRepository.GetByIdAsync(request.Id);

        if (ticketRequest == null)
            throw new NotFoundException(nameof(Domain.TicketRequest), request.Id);

        await _ticketRequestRepository.DeleteAsync(ticketRequest);
    }
}