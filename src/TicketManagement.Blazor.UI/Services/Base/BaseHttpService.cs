using Blazored.LocalStorage;
using System.Net.Http.Headers;

namespace TicketManagement.Blazor.UI.Services.Base;

public class BaseHttpService
{
    protected IClient _client;
    protected readonly ILocalStorageService _localStorage;

    public BaseHttpService(IClient client, ILocalStorageService localStorage)
    {
        _client = client;
        _localStorage = localStorage;
    }

    protected Response<Guid> ConvertApiExceptions<Guid>(ApiException ex)
    {
        return ex.StatusCode switch
        {
            400 => new Response<Guid> { Message = "Invalid data was submitted", ValidationErrors = ex.Response, Success = false },
            404 => new Response<Guid> { Message = "The record was not found", Success = false },
            _ => new Response<Guid> { Message = "Something went wrong, please try again later", Success = false }
        };
    }

    protected async Task AddBearerToken()
    {
        if (await _localStorage.ContainKeyAsync("token"))
            _client.HttpClient.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer", await _localStorage.GetItemAsync<string>("token"));
    }
}