using MediatR;

namespace TicketManagement.Application.Features.TicketAllocation.Commands.Update;

public class UpdateTicketAllocationCommand : IRequest<Unit>
{
    public int Id { get; set; }
    public int NumberOfDays { get; set; }
    public int TicketTypeId { get; set; }
    public int Period { get; set; }
}