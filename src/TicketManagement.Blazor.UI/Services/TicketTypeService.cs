using AutoMapper;
using TicketManagement.Blazor.UI.Contracts;
using TicketManagement.Blazor.UI.Models.TicketTypes;
using TicketManagement.Blazor.UI.Services.Base;

namespace TicketManagement.Blazor.UI.Services;

public class TicketTypeService : BaseHttpService, ITicketTypeService
{
    private readonly IMapper _mapper;

    public TicketTypeService(IClient client, IMapper mapper) : base(client)
    {
        _mapper = mapper;
    }

    public async Task<List<TicketTypeVM>> GetTicketTypes()
    {
        var ticketTypes = await _client.TicketTypesAllAsync();
        return _mapper.Map<List<TicketTypeVM>>(ticketTypes);
    }

    public async Task<TicketTypeVM> GetTicketTypeDetails(int id)
    {
        var ticketType = await _client.IdAsync(id);
        return _mapper.Map<TicketTypeVM>(ticketType);
    }

    public async Task<Response<Guid>> CreateTicketType(TicketTypeVM ticketType)
    {
        try
        {
            var createTicketTypeCommand = _mapper.Map<CreateTicketTypeCommand>(ticketType);
            await _client.TicketTypesPOSTAsync(createTicketTypeCommand);
            return new Response<Guid>()
            {
                Success = true,
            };
        }
        catch (ApiException ex)
        {
            return ConvertApiExceptions <Guid>( ex);
        }
    }

    public async Task<Response<Guid>> UpdateTicketType(int id, TicketTypeVM ticketType)
    {
        try
        {
            var updateTicketTypeCommand = _mapper.Map<UpdateTicketTypeCommand>(ticketType);
            await _client.TicketTypesPUTAsync(id.ToString(), updateTicketTypeCommand);
            return new Response<Guid>()
            {
                Success = true,
            };
        }
        catch (ApiException ex)
        {
            return ConvertApiExceptions <Guid>( ex);
        }
    }

    public async Task<Response<Guid>> DeleteTicketType(int id)
    {
        try
        {
            await _client.TicketTypesDELETEAsync(id);
            return new Response<Guid>() 
            {
                Success = true,
            };
        }
        catch (ApiException ex)
        {
            return ConvertApiExceptions <Guid>( ex);
        }
    }
}