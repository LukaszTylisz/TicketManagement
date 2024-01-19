using AutoMapper;
using Blazored.LocalStorage;
using TicketManagement.Blazor.UI.Contracts;
using TicketManagement.Blazor.UI.Models.TicketAllocations;
using TicketManagement.Blazor.UI.Models.TicketRequests;
using TicketManagement.Blazor.UI.Services.Base;

namespace TicketManagement.Blazor.UI.Services;

public class TicketRequestService : BaseHttpService, ITicketRequestService
{
    private readonly IMapper _mapper;

    public TicketRequestService(IClient client, IMapper mapper, ILocalStorageService localStorage) : base(client, localStorage)
    {
        _mapper=mapper;
    }

    public async Task<Response<Guid>> ResolvedTicketRequest(int id, bool resolved)
    {
        try
        {
            var response = new Response<Guid>();
            var request = new ChangeTicketRequestResolvedCommand { Resolved = resolved, Id = id };
            await _client.UpdateApprovalAsync(request);
            return response;
        }
        catch (ApiException ex)
        {
            return ConvertApiExceptions<Guid>(ex);
        }
    }

    public async Task<Response<Guid>> CancelTicketRequest(int id)
    {
        try
        {
            var response = new Response<Guid>();
            var request = new CancelTicketRequestCommand { Id = id };
            await _client.CancelRequestAsync(request);
            return response;
        }
        catch (ApiException ex)
        {
            return ConvertApiExceptions<Guid>(ex);
        }
    }

    public async Task<Response<Guid>> CreateTicketRequest(TicketRequestVm ticketRequest)
    {
        try
        {
            var response = new Response<Guid>();
            CreateTicketRequestCommand createTicketRequest = _mapper.Map<CreateTicketRequestCommand>(ticketRequest);

            await _client.TicketRequestPOSTAsync(createTicketRequest);
            return response;
        }
        catch (ApiException ex)
        {
            return ConvertApiExceptions<Guid>(ex);
        }
    }

    public async Task DeleteTicketRequest(int id)
    {
        await _client.TicketRequestDELETEAsync(id);
    }

    public async Task<AdminTicketRequestViewVM> GetAdminTicketequestList()
    {
        var ticketRequests = await _client.TicketRequestAllAsync(isLoggedInUser: false);

        var model = new AdminTicketRequestViewVM
        {
            TotalRequests = ticketRequests.Count,
            ApprovedRequests = ticketRequests.Count(q => q.Resolved == true),
            PendingRequests = ticketRequests.Count(q => q.Resolved == null),
            RejectedRequests = ticketRequests.Count(q => q.Resolved == false),
            TicketRequests = _mapper.Map<List<TicketRequestVm>>(ticketRequests)
        };
        return model;
    }

    public async Task<TicketRequestVm> GetTicketRequest(int id)
    {
        var ticketRequest = await _client.TicketRequestGETAsync(id);
        return _mapper.Map<TicketRequestVm>(ticketRequest);
    }

    public async Task<ClientTicketRequestViewVm> GetUserTicketRequests()
    {
        var ticketRequests = await _client.TicketRequestAllAsync(isLoggedInUser: true);
        var allocations = await _client.TicketAllocationAllAsync(isLoggedInUser: true);
        var model = new ClientTicketRequestViewVm
        {
            TicketAllocations = _mapper.Map<List<TicketAllocationVm>>(allocations),
            TicketRequests = _mapper.Map<List<TicketRequestVm>>(ticketRequests)
        };

        return model;
    }
}