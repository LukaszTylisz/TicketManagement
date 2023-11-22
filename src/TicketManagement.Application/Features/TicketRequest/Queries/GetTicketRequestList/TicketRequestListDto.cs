using TicketManagement.Application.Features.TicketType.Queries.GetAllTickets;
using TicketManagement.Application.Models.Identity;

namespace TicketManagement.Application.Features.TicketRequest.Queries.GetTicketRequestList;

public class TicketRequestListDto
{
    public int Id { get; set; }
    public Client Client { get; set; }
    public string RequestingClientId { get; set; }
    public TicketTypeDto TicketType { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public DateTime DateRequested { get; set; }
    public bool? Resolved { get; set; }
    public bool? Cancelled { get; set; }
}