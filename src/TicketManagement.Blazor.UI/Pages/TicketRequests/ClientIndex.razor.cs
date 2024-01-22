using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using TicketManagement.Blazor.UI.Contracts;
using TicketManagement.Blazor.UI.Models.TicketRequests;

namespace TicketManagement.Blazor.UI.Pages.TicketRequests
{
    public partial class ClientIndex
    {
        [Inject] ITicketRequestService ticketRequestService { get; set; }
        [Inject] IJSRuntime js { get; set; }
        [Inject] NavigationManager NavigationManager { get; set; }
        public ClientTicketRequestViewVM Model { get; set; } = new();
        public string Message { get; set; } = string.Empty;

        protected async override Task OnInitializedAsync()
        {

            Model = await ticketRequestService.GetUserTicketRequests();
        }

        async Task CancelRequestAsync(int id)
        {
            var confirm = await js.InvokeAsync<bool>("confirm", "Do you want to cancel this request?");
            if (confirm)
            {
                var response = await ticketRequestService.CancelTicketRequest(id);
                if (response.Success)
                {
                    StateHasChanged();
                }
                else
                {
                    Message = response.Message;
                }
            }
        }
    }
}