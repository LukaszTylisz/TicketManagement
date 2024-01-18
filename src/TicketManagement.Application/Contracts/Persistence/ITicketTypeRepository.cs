using TicketManagement.Domain;

namespace TicketManagement.Application.Contracts.Persistence;

public interface ITicketTypeRepository : IGenericRepository<TicketType>
{
    Task<bool> IsTicketUnique(string name);
}