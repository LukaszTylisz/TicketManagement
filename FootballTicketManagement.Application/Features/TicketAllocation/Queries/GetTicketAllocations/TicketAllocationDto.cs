using FootballTicketManagement.Application.Features.TicketType.Queries.GetAllTickets;

namespace FootballTicketManagement.Application.Features.TicketAllocation.Queries.GetTicketAllocations;

public class TicketAllocationDto
{
    public int Id { get; set; }
    public int NumberOfTickets { get; set; }
    public TicketTypeDto TicketType { get; set; }
    public int TicketTypeId { get; set; }
    public int Period { get; set; }
}