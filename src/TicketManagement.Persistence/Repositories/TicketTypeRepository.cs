using TicketManagement.Application.Contracts.Persistance;
using TicketManagement.Domain;
using Microsoft.EntityFrameworkCore;
using TicketManagement.Persistence.DatabaseContext;

namespace TicketManagement.Persistence.Repositories;

public class TicketTypeRepository : GenericRepository<TicketType>, ITicketTypeRepository
{
    public TicketTypeRepository(TicketManagementDatabaseContext context) : base(context)
    {
    }

    public async Task<bool> IsTicketUnique(string name)
    {
        return await _context.TicketTypes.AnyAsync(q => q.Name == name) == false;
    }
}