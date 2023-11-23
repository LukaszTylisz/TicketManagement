using TicketManagement.Domain.Common;

namespace TicketManagement.Domain;

public class TicketRequest : BaseEntity
{
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public TicketType? TicketType { get; set; }
    public int TicketTypeId { get; set; }
    public DateTime DateRequested { get; set; }
    public string? TicketComments { get; set; }
    public bool? Resolved { get; set; }
    public bool Cancelled { get; set; }
    public string RequestingClientId { get; set; }
}