using Microsoft.AspNetCore.Components;
using TicketManagement.Blazor.UI.Models.TicketTypes;

namespace TicketManagement.Blazor.UI.Pages.TicketTypes
{
    public partial class FormComponent
    {
        [Parameter] public bool Disabled { get; set; } = false;
        [Parameter] public TicketTypeVm TicketType { get; set; }
        [Parameter] public string ButtonText { get; set; } = "Save";
        [Parameter] public EventCallback OnValidSubmit { get; set; }
    }
}