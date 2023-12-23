using System.ComponentModel.DataAnnotations;
using TicketManagement.Blazor.UI.Models.TicketTypes;

namespace TicketManagement.Blazor.UI.Models.TicketAllocations
{
    public class TicketAllocationVm
    {
        public int Id { get; set; }
        [Display(Name = "Number Of Days")]

        public int NumberOfDays { get; set; }
        public DateTime DateCreated { get; set; }
        public int Period { get; set; }

        public TicketTypeVM TicketType { get; set; }
        public int TicketTypeId { get; set; }
    }
}
