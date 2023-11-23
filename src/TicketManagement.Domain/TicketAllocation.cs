using TicketManagement.Domain.Common;

namespace TicketManagement.Domain;

#nullable enable
public class TicketAllocation : BaseEntity
{
    public int NumberOfDays { get; set; }
    public TicketType? TicketType { get; set; }
    public int TicketTypeId { get; set; }

    public int Period { get; set; }
    public string ClientId { get; set; }
}