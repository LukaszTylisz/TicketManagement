namespace TicketManagement.Application.Features.TicketType.Queries.GetAllTickets;

public class TicketTypeDto
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public int DefaultResolutionTime { get; set; }
}