namespace FootballTicketManagement.Application.Features.TicketType.Queries.GetTicketDetails;

public class TicketTypeDetailsDto
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public int DefaultResolutionTime { get; set; }
    public DateTime? DateCreated { get; set; }
    public DateTime? DateModified { get; set; }
}