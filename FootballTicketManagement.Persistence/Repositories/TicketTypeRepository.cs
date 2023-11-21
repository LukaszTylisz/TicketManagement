using FootballTicketManagement.Application.Contracts.Persistance;
using FootballTicketManagement.Domain;
using FootballTicketManagement.Persistence.DatabaseContext;
using Microsoft.EntityFrameworkCore;

namespace FootballTicketManagement.Persistence.Repositories;

public class TicketTypeRepository : GenericRepository<TicketType>, ITicketTypeRepository
{
    public TicketTypeRepository(FmDatabaseContext context) : base(context)
    {
    }

    public async Task<bool> IsTicketUnique(string name)
    {
        return await _context.TicketTypes.AnyAsync(q => q.Name == name) == false;
    }
}