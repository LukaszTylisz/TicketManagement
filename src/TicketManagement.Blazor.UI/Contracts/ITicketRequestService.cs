using TicketManagement.Blazor.UI.Models.TicketRequests;
using TicketManagement.Blazor.UI.Services.Base;

namespace TicketManagement.Blazor.UI.Contracts;

public interface ITicketRequestService
{
    Task<AdminTicketRequestViewVM> GetAdminTicketequestList();
    Task<ClientTicketRequestViewVM> GetUserTicketRequests();
    Task<Response<Guid>> CreateTicketRequest(TicketRequestVm TicketRequest);
    Task<TicketRequestVm> GetTicketRequest(int id);
    Task DeleteTicketRequest(int id);
    Task<Response<Guid>> ResolvedTicketRequest(int id, bool resolved);
    Task<Response<Guid>> CancelTicketRequest(int id);
}