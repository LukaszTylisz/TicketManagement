using AutoMapper;
using Blazored.LocalStorage;
using TicketManagement.Blazor.UI.Contracts;
using TicketManagement.Blazor.UI.Models.TicketTypes;
using TicketManagement.Blazor.UI.Services.Base;

namespace TicketManagement.Blazor.UI.Services;

public class TicketTypeService : BaseHttpService, ITicketTypeService
{
    private readonly IMapper _mapper;

    public TicketTypeService(IClient client, IMapper mapper, ILocalStorageService localStorage) : base(client, localStorage)
    {
        _mapper = mapper;
    }

    public async Task<List<TicketTypeVm>> GetTicketTypes()
    {
        await AddBearerToken();
        var ticketTypes = await _client.TicketTypesAllAsync();
        return _mapper.Map<List<TicketTypeVm>>(ticketTypes);
    }

    public async Task<TicketTypeVm> GetTicketTypeDetails(int id)
    {
        await AddBearerToken();
        var ticketType = await _client.TicketTypesGETAsync(id);
        return _mapper.Map<TicketTypeVm>(ticketType);
    }

    public async Task<Response<Guid>> CreateTicketType(TicketTypeVm ticketType)
    {
        try
        {
            await AddBearerToken();
            var createTicketTypeCommand = _mapper.Map<CreateTicketTypeCommand>(ticketType);
            await _client.TicketTypesPOSTAsync(createTicketTypeCommand);
            return new Response<Guid>()
            {
                Success = true,
            };
        }
        catch (ApiException ex)
        {

            return ConvertApiExceptions<Guid>(ex);
        }
    }

    public async Task<Response<Guid>> UpdateTicketType(int id, TicketTypeVm ticketType)
    {
        try
        {
            await AddBearerToken();
            var updateTicketTypeCommand = _mapper.Map<UpdateTicketTypeCommand>(ticketType);
            await _client.TicketTypesPUTAsync(id.ToString(), updateTicketTypeCommand);

            return new Response<Guid>()
            {
                Success = true,
            };
        }
        catch (ApiException ex)
        {
            return ConvertApiExceptions<Guid>(ex);
        }
    }

    public async Task<Response<Guid>> DeleteTicketType(int id)
    {
        try
        {
            await AddBearerToken();
            await _client.TicketTypesDELETEAsync(id);
            return new Response<Guid>()
            {
                Success = true,
            };
        }
        catch (ApiException ex)
        {
            return ConvertApiExceptions<Guid>(ex);
        }
    }
}