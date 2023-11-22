using TicketManagement.Application.Features.TicketType.Queries.GetAllTickets;

namespace TicketManagement.Application.Features.TicketAllocation.Queries.GetTitcketAllocationsDetails;

public class TicketAllocationsDetailsDto
{
    public int Id { get; set; }
    public int NumberOfDays { get; set; }
    public TicketTypeDto TicketType { get; set; }
    public int TicketTypeId { get; set; }
    public int Period { get; set; }
}