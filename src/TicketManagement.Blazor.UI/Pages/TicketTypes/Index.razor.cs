using Microsoft.AspNetCore.Components;
using TicketManagement.Blazor.UI.Contracts;
using TicketManagement.Blazor.UI.Models.TicketTypes;

namespace TicketManagement.Blazor.UI.Pages.TicketTypes;

public partial class Index
{
    [Inject]
    public NavigationManager NavigationManager { get; set; }
    
    [Inject]
    public ITicketTypeService TicketTypeService { get; set; }
    [Inject]
    public ITicketAllocationService TicketAllocationService { get; set; }
    public List<TicketTypeVm> TicketTypes {  get; private set; }
    public string Message { get; set; } = string.Empty;
    protected void CreateTicketType()
    {
        NavigationManager.NavigateTo("/tickettypes/create/");
    }

    protected void AllocateTicketType(int id)
    {
        TicketAllocationService.CreateTicketAllocations(id);
    }

    protected void EditTicketType(int id)
    {
        NavigationManager.NavigateTo($"/tickettypes/edit/{id}");
    }

    protected void DetailsTicketType(int id)
    {
        NavigationManager.NavigateTo($"/tickettypes/details/{id}");
    }

    protected async Task DeleteTicketType(int id)
    {
        var response = await TicketTypeService.DeleteTicketType(id);
        if (response.Success)
        {
            await OnInitializedAsync();
        }
        else
        {
            Message = response.Message;
        }
    }

    protected override async Task OnInitializedAsync()
    {
        TicketTypes = await TicketTypeService.GetTicketTypes();
    }
}