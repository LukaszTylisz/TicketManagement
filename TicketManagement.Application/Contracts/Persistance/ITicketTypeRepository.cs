using TicketManagement.Domain;

namespace TicketManagement.Application.Contracts.Persistance;

public interface ITicketTypeRepository : IGenericRepository<TicketType>
{
    Task<bool> IsTicketUnique(string name);
}