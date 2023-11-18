using FootballTicketManagement.Domain;

namespace FootballTicketManagement.Application.Contracts.Persistance;

public interface ITicketRepository : IGenericRepository<Ticket>
{
    Task<Ticket> GetLeaveRequestWithDetails(int id);
    Task<List<Ticket>> GetLeaveRequestsWithDetails();
    Task<List<Ticket>> GetLeaveRequestsWithDetails(string userId);
}