namespace TicketManagement.Blazor.UI.Services.Base;

public partial interface IClient
{
    public HttpClient HttpClient { get; }
}