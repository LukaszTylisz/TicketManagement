using TicketManagement.Blazor.UI.Contracts;
using TicketManagement.Blazor.UI.Services.Base;

namespace TicketManagement.Blazor.UI.Services;

public class TicketRequestService : BaseHttpService, ITicketRequestService
{
    public TicketRequestService(IClient client) : base(client)
    {
    }
}