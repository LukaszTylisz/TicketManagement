using TicketManagement.Domain;

namespace TicketManagement.Application.Contracts.Persistence;

public interface ITicketAllocationRepository : IGenericRepository<TicketAllocation>
{
    Task<TicketAllocation> GetTicketAllocationDetails(int id);
    Task<List<TicketAllocation>> GetTicketAllocationWithDetails();
    Task<List<TicketAllocation>> GetTicketAllocationsWithDetails(string userId);
    Task<bool> AllocationExists(string userId, int ticketTypeId, int period);
    Task AddAllocations(List<TicketAllocation> allocations);
    Task<TicketAllocation> GetUserAllocations(string userId, int ticketTypeId);
}