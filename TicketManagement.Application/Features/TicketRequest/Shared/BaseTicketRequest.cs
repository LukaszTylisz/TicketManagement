namespace TicketManagement.Application.Features.TicketRequest.Shared
{
    public abstract class BaseTicketRequest
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int TicketTypeId { get; set; }
    }
}
