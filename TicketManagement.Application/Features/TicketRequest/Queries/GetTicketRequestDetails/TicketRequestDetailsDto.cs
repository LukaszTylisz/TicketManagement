using TicketManagement.Application.Features.TicketType.Queries.GetAllTickets;

namespace TicketManagement.Application.Features.TicketRequest.Queries.GetTicketRequestDetails;

public class TicketRequestDetailsDto
{
    public int Id { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public DateTime DateRequested { get; set; }
    public TicketTypeDto TicketType { get; set; }
    public int TicketTypeId { get; set; }
    public string TicketComments { get; set; }
    public DateTime? DateActioned { get; set; }
    public bool Resolved { get; set; }
    public bool Cancelled { get; set; }
    public string RequestingClientId { get; set; }
}