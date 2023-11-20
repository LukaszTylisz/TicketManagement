using AutoMapper;
using FootballTicketManagement.Application.Contracts.Persistance;
using FootballTicketManagement.Application.Exceptions;
using MediatR;

namespace FootballTicketManagement.Application.Features.TicketAllocation.Commands.Delete
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
            var leaveAllocation = await _ticketAllocationRepository.GetByIdAsync(request.Id);

            if (leaveAllocation == null)
                throw new NotFoundException(nameof(TicketAllocation), request.Id);

            await _ticketAllocationRepository.DeleteAsync(leaveAllocation);
        }
    }
}
