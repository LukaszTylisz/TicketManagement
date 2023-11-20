using FootballTicketManagement.Application.Features.TicketType.Queries.GetAllTickets;

namespace FootballTicketManagement.Application.Features.TicketRequest.Queries.GetTicketRequestDetails;

public class TicketRequestDetailsDto
{
    public int Id { get; set; }
    public DateTime MatchStartDate { get; set; }
    public DateTime MatchEndDate { get; set; }
    public DateTime DateRequested { get; set; }
    public TicketTypeDto TicketType { get; set; }
    public int TicketTypeId { get; set; }
    public string TicketComments { get; set; }
    public DateTime? DateActioned { get; set; }
    public bool Resolved { get; set; }
    public bool Cancelled { get; set; }
    public string RequestingClientId { get; set; }
}