using TicketManagement.Application.Contracts.Persistance;
using TicketManagement.Domain;
using Microsoft.EntityFrameworkCore;
using TicketManagement.Persistence.DatabaseContext;

namespace TicketManagement.Persistence.Repositories;

public class TicketAllocationRepository : GenericRepository<TicketAllocation>, ITicketAllocationRepository
{
    public TicketAllocationRepository(FmDatabaseContext context) : base(context)
    {
    }

    public async Task<TicketAllocation> GetTicketAllocationDetails(int id)
    {
        var ticketAllocations = await _context.TicketAllocations
            .Include(q => q.TicketType)
            .FirstOrDefaultAsync(q => q.Id == id);

        return ticketAllocations;
    }

    public async Task<List<TicketAllocation>> GetTicketAllocationWithDetails()
    {
        var ticketAllocations = await _context.TicketAllocations
            .Include(q => q.TicketType)
            .ToListAsync();

        return ticketAllocations;
    }

    public async Task<List<TicketAllocation>> GetTicketAllocationsWithDetails(string userId)
    {
        var ticketAllocations = await _context.TicketAllocations
            .Where(q => q.ClientId == userId)
            .Include(q => q.TicketType)
            .ToListAsync();

        return ticketAllocations;
    }

    public async Task<bool> AllocationExists(string userId, int ticketTypeId, int period)
    {
        return await _context.TicketAllocations.AnyAsync(q => q.ClientId == userId
                                                              && q.TicketTypeId == ticketTypeId
                                                              && q.Period == period);
    }

    public async Task AddAllocations(List<TicketAllocation> allocations)
    {
        await _context.AddRangeAsync(allocations);
        await _context.SaveChangesAsync();
    }

    public Task<TicketAllocation> GetUserAllocations(string userId, int ticketTypeId)
    {
        throw new NotImplementedException();
    }
}