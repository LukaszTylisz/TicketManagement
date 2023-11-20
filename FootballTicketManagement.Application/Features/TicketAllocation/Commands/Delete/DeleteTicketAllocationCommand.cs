using MediatR;

namespace FootballTicketManagement.Application.Features.TicketAllocation.Commands.Delete
{
    public class DeleteTicketAllocationCommand : IRequest
    {
        public int Id { get; set; }
    }
}
