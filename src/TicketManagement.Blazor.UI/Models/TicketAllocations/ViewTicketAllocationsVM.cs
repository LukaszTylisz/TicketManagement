namespace TicketManagement.Blazor.UI.Models.TicketAllocations
{
    public class ViewTicketAllocationsVm
    {
        public string ClientId { get; set; }
        public List<TicketAllocationVm> TicketAllocations { get; set; }
    }
}
