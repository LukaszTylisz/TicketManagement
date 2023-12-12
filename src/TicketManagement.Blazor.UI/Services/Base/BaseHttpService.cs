namespace TicketManagement.Blazor.UI.Services.Base;

public class BaseHttpService
{
    protected IClient _client;

    public BaseHttpService(IClient client)
    {
        _client = client;
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
}