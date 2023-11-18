using FootballTicketManagement.Domain.Common;

namespace FootballTicketManagement.Domain;

public class TicketAllocation : BaseEntity  
{
    public int NumberOfTickets { get; set; }

    public TicketType? TicketType { get; set; }
    public int TicketTypeId { get; set; }

    public int Period { get; set; }
    //public string ClientId { get; set; } = string.Empty;
}