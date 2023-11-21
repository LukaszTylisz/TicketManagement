using MediatR;

namespace TicketManagement.Application.Features.TicketAllocation.Commands.Delete
{
    public class DeleteTicketAllocationCommand : IRequest
    {
        public int Id { get; set; }
    }
}
