using TicketManagement.Blazor.UI.Services.Base;

namespace TicketManagement.Blazor.UI.Contracts;

public interface ITicketAllocationService
{
    Task<Response<Guid>> CreateTicketAllocations(int ticketTypeId);
}