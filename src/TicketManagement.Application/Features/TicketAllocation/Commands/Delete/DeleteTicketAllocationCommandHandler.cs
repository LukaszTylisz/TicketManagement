using AutoMapper;
using MediatR;
using TicketManagement.Application.Contracts.Persistence;
using TicketManagement.Application.Exceptions;

namespace TicketManagement.Application.Features.TicketAllocation.Commands.Delete
{
    public class DeleteTicketAllocationCommandHandler(
        IMapper mapper,
        ITicketAllocationRepository ticketAllocationRepository)
        : IRequestHandler<DeleteTicketAllocationCommand>
    {
        private readonly IMapper _mapper = mapper;

        public async Task Handle(DeleteTicketAllocationCommand request, CancellationToken cancellationToken)
        {
            var ticketAllocation = await ticketAllocationRepository.GetByIdAsync(request.Id);

            if (ticketAllocation == null)
                throw new NotFoundException(nameof(TicketAllocation), request.Id);

            await ticketAllocationRepository.DeleteAsync(ticketAllocation);
        }
    }
}
