using FootballTicketManagement.Domain;

namespace FootballTicketManagement.Application.Contracts.Persistance;

public interface ITicketTypeAllocationRepository : IGenericRepository<TicketAllocation>
{
    Task<TicketAllocation> GetTicketAllocationDetails(int id);
    Task<List<TicketAllocation>> GetTicketAllocationWithDetails(string userId);
    Task<List<TicketAllocation>> GetLeaveAllocationsWithDetails(string userId);
    Task<bool> AllocationExists(string userId, int leaveTypeId, int period);
    Task AddAllocations(List<TicketAllocation> allocations);
    Task<TicketAllocation> GetUserAllocations(string userId, int leaveTypeId);
}