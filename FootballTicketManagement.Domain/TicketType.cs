using FootballTicketManagement.Domain.Common;

namespace FootballTicketManagement.Domain;

public class TicketType : BaseEntity
{
      public string Name { get; set; } = string.Empty;
      public int DefaultResolutionTime { get; set; }
}