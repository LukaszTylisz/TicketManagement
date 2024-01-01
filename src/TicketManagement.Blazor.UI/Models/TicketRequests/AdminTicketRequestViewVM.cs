namespace TicketManagement.Blazor.UI.Models.TicketRequests
{
    public class AdminTicketRequestViewVM
    {
        public int TotalRequests { get; set; }
        public int ApprovedRequests { get; set; }
        public int PendingRequests { get; set; }
        public int RejectedRequests { get; set; }
        public List<TicketRequestVm> TicketRequests { get; set; } = new List<TicketRequestVm>();
    }
}
