using FootballTicketManagement.Domain.Common;

namespace FootballTicketManagement.Domain;

public class TicketType : BaseEntity
{
      public int Id { get; set; }
      public string Name { get; set; }
      public int DefaultResolutionTime { get; set; }
}