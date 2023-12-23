using Blazored.LocalStorage;
using TicketManagement.Blazor.UI.Contracts;
using TicketManagement.Blazor.UI.Services.Base;

namespace TicketManagement.Blazor.UI.Services;

public class TicketAllocationService : BaseHttpService, ITicketAllocationService
{
    public TicketAllocationService(IClient client, ILocalStorageService localStorageService) : base(client, localStorageService)
    {
    }

    public async Task<Response<Guid>> CreateTicketAllocations(int ticketTypeId)
    {
        try
        {
            var response = new Response<Guid>();
            CreateTicketAllocationCommand createTicketAllocationCommand = new() { TicketTypeId = ticketTypeId };

            await _client.TicketAllocationPOSTAsync(createTicketAllocationCommand);
            return response;
        }
        catch (ApiException ex)
        {
            return ConvertApiExceptions<Guid>(ex);
        }
    }
}