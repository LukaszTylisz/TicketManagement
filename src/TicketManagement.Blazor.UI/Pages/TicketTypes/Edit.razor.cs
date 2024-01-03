using Microsoft.AspNetCore.Components;
using TicketManagement.Blazor.UI.Contracts;
using TicketManagement.Blazor.UI.Models.TicketTypes;

namespace TicketManagement.Blazor.UI.Pages.TicketTypes
{
    public partial class Edit
    {
        [Inject]
        ITicketTypeService _client { get; set; }

        [Inject]
        NavigationManager _navManager { get; set; }

        [Parameter]
        public int id { get; set; }
        public string Message { get; private set; }

        TicketTypeVM ticketType = new TicketTypeVM();

        protected async Task OnParametersSetAsync()
        {
            ticketType = await _client.GetTicketTypeDetails(id);
        }

        async Task EditTicketType()
        {
            var response = await _client.UpdateTicketType(id, ticketType);
            if (response.Success)
            {
                _navManager.NavigateTo("/tickettypes/");
            }
            Message = response.Message;
        }
    }
}