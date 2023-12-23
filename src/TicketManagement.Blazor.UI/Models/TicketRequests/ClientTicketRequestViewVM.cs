using TicketManagement.Blazor.UI.Models.TicketAllocations;

namespace TicketManagement.Blazor.UI.Models.TicketRequests
{
    public class ClientTicketRequestViewVm
    {
        public List<TicketAllocationVm> TicketAllocations { get; set; } = new List<TicketAllocationVm>();
        public List<TicketRequestVm> TicketRequests { get; set; } = new List<TicketRequestVm>();
    }
}
