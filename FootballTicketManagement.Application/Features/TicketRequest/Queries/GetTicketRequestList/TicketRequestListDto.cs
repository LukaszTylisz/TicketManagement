using FootballTicketManagement.Application.Features.TicketType.Queries.GetAllTickets;

namespace FootballTicketManagement.Application.Features.TicketRequest.Queries.GetTicketRequestList;

public class TicketRequestListDto
{
    public int Id { get; set; }
    public TicketTypeDto TicketType { get; set; }
    public DateTime MatchStartDate { get; set; }
    public DateTime MatchEndDate { get; set; }
    public DateTime DateRequested { get; set; }
    public string TicketComments { get; set; }
    public bool? Resolved { get; set; }
    public bool? Cancelled { get; set; }
}