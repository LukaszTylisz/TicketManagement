using Microsoft.AspNetCore.Components;
using TicketManagement.Blazor.UI.Contracts;
using TicketManagement.Blazor.UI.Models.TicketTypes;

namespace TicketManagement.Blazor.UI.Pages.TicketTypes
{
    public partial class Details
    {
        [Inject]
        ITicketTypeService _client { get; set; }

        [Parameter]
        public int id { get; set; }

        TicketTypeVm ticketType = new TicketTypeVm();

        protected async override Task OnParametersSetAsync()
        {
            ticketType = await _client.GetTicketTypeDetails(id);
        }
    }
}