using TicketManagement.Blazor.UI.Models.TicketAllocations;

namespace HR.LeaveManagement.BlazorUI.Models.LeaveAllocations
{
    public class ViewTicketAllocationsVM
    {
        public string ClientId { get; set; }
        public List<TicketAllocationVm> TicketAllocations { get; set; }
    }
}
