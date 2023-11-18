using FootballTicketManagement.Domain;

namespace FootballTicketManagement.Application.Contracts.Persistance;

public interface ITicketTypeRepository : IGenericRepository<TicketType>
{
    Task<bool> IsTicketUnique(string name);
}