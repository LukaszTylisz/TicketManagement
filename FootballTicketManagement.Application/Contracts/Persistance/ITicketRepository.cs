using FootballTicketManagement.Domain;

namespace FootballTicketManagement.Application.Contracts.Persistance;

public interface ITicketRepository : IGenericRepository<Ticket>
{
    Task<Ticket> GetTicketWithDetails(int id);
    Task<List<Ticket>> GetTicketWithDetails();
    Task<List<Ticket>> GetTicketWithDetails(string userId);
}