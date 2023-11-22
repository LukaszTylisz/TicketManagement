using AutoMapper;
using MediatR;
using TicketManagement.Application.Contracts.Persistance;
using TicketManagement.Application.Exceptions;

namespace TicketManagement.Application.Features.TicketAllocation.Commands.Delete
{
    public class DeleteTicketAllocationCommandHandler : IRequestHandler<DeleteTicketAllocationCommand>
    {
        private readonly ITicketAllocationRepository _ticketAllocationRepository;
        private readonly IMapper _mapper;

        public DeleteTicketAllocationCommandHandler(IMapper mapper, ITicketAllocationRepository ticketAllocationRepository)
        {
            _mapper = mapper;
            _ticketAllocationRepository = ticketAllocationRepository;
        }

        public async Task Handle(DeleteTicketAllocationCommand request, CancellationToken cancellationToken)
        {
            var ticketAllocation = await _ticketAllocationRepository.GetByIdAsync(request.Id);

            if (ticketAllocation == null)
                throw new NotFoundException(nameof(TicketAllocation), request.Id);

            await _ticketAllocationRepository.DeleteAsync(ticketAllocation);
        }
    }
}
