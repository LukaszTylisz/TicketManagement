using TicketManagement.Domain.Common;

namespace TicketManagement.Domain;

public class TicketType : BaseEntity
{
      public string Name { get; set; } = string.Empty;
      public int DefaultDays { get; set; }
}