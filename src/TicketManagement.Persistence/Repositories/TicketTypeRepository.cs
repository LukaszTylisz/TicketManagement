using TicketManagement.Domain;
using Microsoft.EntityFrameworkCore;
using TicketManagement.Application.Contracts.Persistence;
using TicketManagement.Persistence.DatabaseContext;

namespace TicketManagement.Persistence.Repositories;

public class TicketTypeRepository(TicketManagementDatabaseContext context)
    : GenericRepository<TicketType>(context), ITicketTypeRepository
{
    public async Task<bool> IsTicketUnique(string name)
    {
        return await _context.TicketTypes.AnyAsync(q => q.Name == name) == false;
    }
}