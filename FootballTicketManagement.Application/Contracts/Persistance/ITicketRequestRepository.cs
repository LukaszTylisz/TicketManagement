using FootballTicketManagement.Domain;

namespace FootballTicketManagement.Application.Contracts.Persistance;

public interface ITicketRequestRepository : IGenericRepository<TicketRequest>
{
    Task<TicketRequest> GetTicketWithDetails(int id);
    Task<List<TicketRequest>> GetTicketWithDetails();
    Task<List<TicketRequest>> GetTicketWithDetails(string userId);
}