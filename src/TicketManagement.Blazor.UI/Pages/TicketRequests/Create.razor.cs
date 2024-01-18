using Microsoft.AspNetCore.Components;
using TicketManagement.Blazor.UI.Contracts;
using TicketManagement.Blazor.UI.Models.TicketRequests;
using TicketManagement.Blazor.UI.Models.TicketTypes;

namespace TicketManagement.Blazor.UI.Pages.TicketRequests;
public partial class Create
{
    [Inject] ITicketTypeService ticketTypeService { get; set; }
    [Inject] ITicketRequestService ticketRequestService { get; set; }
    [Inject] NavigationManager NavigationManager { get; set; }
    TicketRequestVm TicketRequest { get; set; } = new TicketRequestVm();
    List<TicketTypeVm> ticketTypesVMs = new List<TicketTypeVm>();

    protected override async Task OnInitializedAsync()
    {
        ticketTypesVMs = await ticketTypeService.GetTicketTypes();
    }

    private async void HandleValidSubmit()
    {
        await ticketRequestService.CreateTicketRequest(TicketRequest);
        NavigationManager.NavigateTo("/ticketrequests/");
    }
}