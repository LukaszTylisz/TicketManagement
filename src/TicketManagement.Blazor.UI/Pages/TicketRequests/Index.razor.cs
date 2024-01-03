using Microsoft.AspNetCore.Components;
using TicketManagement.Blazor.UI.Contracts;
using TicketManagement.Blazor.UI.Models.TicketRequests;

namespace TicketManagement.Blazor.UI.Pages.TicketRequests;
public partial class Index
{
    [Inject] ITicketRequestService ticketRequestService { get; set; }
    [Inject] NavigationManager NavigationManager { get; set; }
    public AdminTicketRequestViewVM Model { get; set; } = new();

    protected async override Task OnInitializedAsync()
    {
        Model = await ticketRequestService.GetAdminTicketequestList();
    }

    void GoToDetails(int id)
    {
        NavigationManager.NavigateTo($"/ticketrequests/details/{id}");
    }
}