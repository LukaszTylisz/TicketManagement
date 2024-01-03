using Microsoft.AspNetCore.Components;
using TicketManagement.Blazor.UI.Contracts;
using TicketManagement.Blazor.UI.Models.TicketRequests;

namespace TicketManagement.Blazor.UI.Pages.TicketRequests;
public partial class Details
{
    [Inject] ITicketRequestService ticketRequestService { get; set; }
    [Inject] NavigationManager navigationManager { get; set; }
    [Parameter] public int id { get; set; }

    string ClassName;
    string HeadingText;

    public TicketRequestVm Model { get; private set; } = new TicketRequestVm();

    protected override async Task OnParametersSetAsync()
    {
        Model = await ticketRequestService.GetTicketRequest(id);
    }

    protected override async Task OnInitializedAsync()
    {
        if (Model.Approved == null)
        {
            ClassName = "warning";
            HeadingText = "Pending Approval";
        }
        else if (Model.Approved == true)
        {
            ClassName = "success";
            HeadingText = "Approved";
        }
        else
        {
            ClassName = "danger";
            HeadingText = "Rejected";
        }
    }

    async Task ChangeApproval(bool approvalStatus)
    {
        await ticketRequestService.ResolvedTicketRequest(id, approvalStatus);
        navigationManager.NavigateTo("/ticketrequests/");
    }
}