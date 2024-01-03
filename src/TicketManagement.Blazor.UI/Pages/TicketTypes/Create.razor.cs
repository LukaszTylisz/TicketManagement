using Blazored.Toast.Services;
using Microsoft.AspNetCore.Components;
using TicketManagement.Blazor.UI.Contracts;
using TicketManagement.Blazor.UI.Models.TicketTypes;

namespace TicketManagement.Blazor.UI.Pages.TicketTypes;
public partial class Create
{
    [Inject]
    NavigationManager _navManager { get; set; }
    [Inject]
    ITicketTypeService _client { get; set; }
    [Inject]
    IToastService toastService { get; set; }
    public string Message { get; private set; }

    TicketTypeVM ticketType = new TicketTypeVM();
    async Task CreateTicketType()
    {
        var response = await _client.CreateTicketType(ticketType);
        if (response.Success)
        {
            toastService.ShowSuccess("Ticket Type created Successfully");
            toastService.ShowToast(ToastLevel.Info, "Test");
            _navManager.NavigateTo("/tickettypes/");
        }
        Message = response.Message;
    }
}